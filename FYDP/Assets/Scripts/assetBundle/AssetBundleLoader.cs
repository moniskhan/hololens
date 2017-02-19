using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AssetBundles
{

    public class LoadedAssetBundle
    {
        public AssetBundle m_AssetBundle;
        public int m_ReferencedCount;

        internal event Action unload;

        internal void OnUnload()
        {
            m_AssetBundle.Unload(false);
            if (unload != null)
                unload();
        }

        public LoadedAssetBundle(AssetBundle assetBundle)
        {
            m_AssetBundle = assetBundle;
            m_ReferencedCount = 1;
        }
    }

    public class AssetBundleLoader : MonoBehaviour {

        public enum AssetRequestType { MANIFEST, ASSET };

        static string m_AssetBundleUrl = "";

        static AssetBundleManifest m_AssetBundleManifest = null;
        static string[] m_ActiveVariants = { };

        static Dictionary<string, LoadedAssetBundle> m_LoadedAssetBundles = new Dictionary<string, LoadedAssetBundle>();
        static Dictionary<string, string> m_DownloadingErrors = new Dictionary<string, string>();

        static List<string> m_DownloadingBundles = new List<string>();
        static List<AssetBundleLoadOperation> m_InProgressOperations = new List<AssetBundleLoadOperation>();
        static Dictionary<string, string[]> m_Dependencies = new Dictionary<string, string[]>();

        public static AssetBundleManifest AssetBundleManifestObject
        {
            set { m_AssetBundleManifest = value; }
        }

        public static string[] ActiveVariants
        {
            get { return m_ActiveVariants; }
            set { m_ActiveVariants = value; }
        }

        public static void setAssetBundleUrl(string url)
        {
            m_AssetBundleUrl = url;
        }

        static public AssetBundleLoadManifestOperation Initialize(string manifestAssetBundleName)
        {
            var go = new GameObject("AssetBundleManager", typeof(AssetBundleLoader));
            DontDestroyOnLoad(go);

            LoadAssetBundle(manifestAssetBundleName, AssetRequestType.MANIFEST);

            var operation = new AssetBundleLoadManifestOperation(manifestAssetBundleName, "AssetBundleManifest", typeof(AssetBundleManifest));
            m_InProgressOperations.Add(operation);
            return operation;
        }

        static public AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundleName, string assetName, System.Type type)
        {
            Debug.Log("Loading " + assetName + " from " + assetBundleName + " bundle");

            AssetBundleLoadAssetOperation operation = null;

            assetBundleName = RemapVariantName(assetBundleName);
            LoadAssetBundle(assetBundleName, AssetRequestType.ASSET);
            operation = new AssetBundleLoadAssetOperationFull(assetBundleName, assetName, type);
            m_InProgressOperations.Add(operation);

            return operation;
        }

        static public LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName, out string error)
        {
            // if download fails, return null
            if (m_DownloadingErrors.TryGetValue(assetBundleName, out error))
                return null;

            LoadedAssetBundle bundle = null;
            // if download isn't complete, return null
            m_LoadedAssetBundles.TryGetValue(assetBundleName, out bundle);
            if (bundle == null)
                return null;

            // No dependencies are recorded, only the bundle itself is required.
            string[] dependencies = null;
            if (!m_Dependencies.TryGetValue(assetBundleName, out dependencies))
                return bundle;

            // Make sure all dependencies are loaded
            foreach (var dependency in dependencies)
            {
                if (m_DownloadingErrors.TryGetValue(dependency, out error))
                    return null;

                // Wait all the dependent assetBundles being loaded.
                LoadedAssetBundle dependentBundle;
                m_LoadedAssetBundles.TryGetValue(dependency, out dependentBundle);
                if (dependentBundle == null)
                    return null;
            }

            return bundle;
        }

        static public bool IsAssetBundleDownloaded(string assetBundleName)
        {
            return m_LoadedAssetBundles.ContainsKey(assetBundleName);
        }

        static protected void LoadAssetBundle(string assetBundleName, AssetRequestType type)
        {
            if (type != AssetRequestType.MANIFEST && m_AssetBundleManifest == null)
            {
                Debug.Log("Manifest not initialized!");
                return;
            }

            // use cache if the bundle has been loaded before
            bool isCached = LoadAssetBundleRequest(assetBundleName, type);
            if (!isCached && type != AssetRequestType.MANIFEST)
                LoadDependencies(assetBundleName);
        }

        static protected bool LoadAssetBundleRequest(string assetBundleName, AssetRequestType type) 
        {
            LoadedAssetBundle bundle = null;
            m_LoadedAssetBundles.TryGetValue(assetBundleName, out bundle);
            if (bundle != null)
            {
                bundle.m_ReferencedCount++;
                return true;
            }

            if (m_DownloadingBundles.Contains(assetBundleName))
                return true;

            WWW www = null;
            string url = m_AssetBundleUrl + "/" + assetBundleName;
            if (type == AssetRequestType.MANIFEST)
                www = new WWW(url);
            else if (type == AssetRequestType.ASSET)
                www = WWW.LoadFromCacheOrDownload(url, m_AssetBundleManifest.GetAssetBundleHash(assetBundleName), 0);

            m_InProgressOperations.Add(new AssetBundleDownloadFromWebOperation(assetBundleName, www));
            m_DownloadingBundles.Add(assetBundleName);
            return false;
        }

        static protected void LoadDependencies(string assetBundleName)
        {
            if (m_AssetBundleManifest == null)
            {
                Debug.Log("Please initialize AssetBundleManifest first!");
                return;
            }

            // Get dependecies from the AssetBundleManifest object..
            string[] dependencies = m_AssetBundleManifest.GetAllDependencies(assetBundleName);
            if (dependencies.Length == 0)
                return;

            for (int i = 0; i < dependencies.Length; i++)
                dependencies[i] = RemapVariantName(dependencies[i]);

            // Record and load all dependencies.
            m_Dependencies.Add(assetBundleName, dependencies);
            for (int i = 0; i < dependencies.Length; i++)
                LoadAssetBundleRequest(dependencies[i], AssetRequestType.ASSET);
        }

        // Remaps the asset bundle name to the best fitting asset bundle variant.
        static protected string RemapVariantName(string assetBundleName)
        {
            string[] bundlesWithVariant = m_AssetBundleManifest.GetAllAssetBundlesWithVariant();

            // Get base bundle name
            string baseName = assetBundleName.Split('.')[0];

            int bestFit = int.MaxValue;
            int bestFitIndex = -1;
            // Loop all the assetBundles with variant to find the best fit variant assetBundle.
            for (int i = 0; i < bundlesWithVariant.Length; i++)
            {
                string[] curSplit = bundlesWithVariant[i].Split('.');
                string curBaseName = curSplit[0];
                string curVariant = curSplit[1];

                if (curBaseName != baseName)
                    continue;

                int found = System.Array.IndexOf(m_ActiveVariants, curVariant);

                // If there is no active variant found. We still want to use the first
                if (found == -1)
                    found = int.MaxValue - 1;

                if (found < bestFit)
                {
                    bestFit = found;
                    bestFitIndex = i;
                }
            }

            if (bestFit == int.MaxValue - 1)
            {
                Debug.Log("Ambigious asset bundle variant chosen because there was no matching active variant: " + bundlesWithVariant[bestFitIndex]);
            }

            if (bestFitIndex != -1)
            {
                return bundlesWithVariant[bestFitIndex];
            }
            else
            {
                return assetBundleName;
            }
        }

        static public void UnloadAssetBundle(string assetBundleName)
        {
            assetBundleName = RemapVariantName(assetBundleName);
            UnloadAssetBundleInternal(assetBundleName);
            UnloadDependencies(assetBundleName);
        }

        static protected void UnloadAssetBundleInternal(String assetBundleName)
        {
            string error;
            LoadedAssetBundle bundle = GetLoadedAssetBundle(assetBundleName, out error);
            if (bundle == null)
                return;

            if (--bundle.m_ReferencedCount == 0)
            {
                bundle.OnUnload();
                m_LoadedAssetBundles.Remove(assetBundleName);
                Debug.Log(assetBundleName + " has been unloaded successfully");
            }
        }

        static protected void UnloadDependencies(string assetBundleName)
        {
            string[] dependencies = null;
            if (!m_Dependencies.TryGetValue(assetBundleName, out dependencies))
                return;

            // Loop dependencies.
            foreach (var dependency in dependencies)
            {
                UnloadAssetBundleInternal(dependency);
            }

            m_Dependencies.Remove(assetBundleName);
        }

        void Update()
        {
            // Update all in progress operations
            for (int i = 0; i < m_InProgressOperations.Count;)
            {
                var operation = m_InProgressOperations[i];
                if (operation.Update())
                {
                    i++;
                }
                else
                {
                    m_InProgressOperations.RemoveAt(i);
                    ProcessFinishedOperation(operation);
                }
            }
        }

        void ProcessFinishedOperation(AssetBundleLoadOperation operation)
        {
            AssetBundleDownloadOperation download = operation as AssetBundleDownloadOperation;
            if (download == null)
                return;

            if (download.error == null)
            {
                Debug.Log("Loaded AssetBundle " + download.assetBundleName);
                m_LoadedAssetBundles.Add(download.assetBundleName, download.assetBundle);
            }
            else
            {
                string msg = string.Format("Failed downloading bundle {0} from {1}: {2}",
                        download.assetBundleName, download.GetSourceURL(), download.error);
                m_DownloadingErrors.Add(download.assetBundleName, msg);
            }

            m_DownloadingBundles.Remove(download.assetBundleName);
        }
    }
}

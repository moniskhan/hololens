using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;

namespace AssetBundles
{
    public class AssetBundleBuilder : MonoBehaviour
    {
        private const string assetBundlesPath = "AssetBundles";

        [MenuItem ("Assets/Build AssetBundles")]
        public static void BuildAssetBundles()
        {
            // create directory if not exists
            if (!Directory.Exists(assetBundlesPath))
            {
                Directory.CreateDirectory(assetBundlesPath);
            }

            BuildPipeline.BuildAssetBundles(assetBundlesPath, BuildAssetBundleOptions.None, BuildTarget.WSAPlayer);
        }
    }
}

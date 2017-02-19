using UnityEngine;
using System.Collections;
using AssetBundles;


public class LoadAssets : MonoBehaviour
{
    public const string AssetBundlesOutputPath = "/AssetBundles/";
    public string assetBundleName;
    public string assetName;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return StartCoroutine(Initialize());

        // Load asset.
        string assetBundleName = "sofa";
        //string assetName = "IKEA-Jules_Swivel_Chair-3D";
        string assetName = "IKEA-Solsta_2_Seats_Sofa-3D";
        yield return StartCoroutine(InstantiateGameObjectAsync(assetBundleName, assetName));
    }

    void InitializeSourceURL()
    {
        string url = "https://dl.dropboxusercontent.com/u/49884199/AssetBundles";
        AssetBundleLoader.setAssetBundleUrl(url);
    }

    // Initialize the downloading url and AssetBundleManifest object.
    protected IEnumerator Initialize()
    {
        // Don't destroy this gameObject as we depend on it to run the loading script.
        DontDestroyOnLoad(gameObject);

        InitializeSourceURL();

        string assetBundleName = "AssetBundles";
        // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
        var request = AssetBundleLoader.Initialize(assetBundleName);
        if (request != null)
            yield return StartCoroutine(request);
    }

    protected IEnumerator InstantiateGameObjectAsync(string assetBundleName, string assetName)
    {
        Debug.Log(">>>" + assetBundleName + "  " + assetName);
        // This is simply to get the elapsed time for this phase of AssetLoading.
        float startTime = Time.realtimeSinceStartup;

        // Load asset from assetBundle.
        AssetBundleLoadAssetOperation request = AssetBundleLoader.LoadAssetAsync(assetBundleName, assetName, typeof(GameObject));
        if (request == null)
            yield break;
        yield return StartCoroutine(request);

        // Get the asset.
        GameObject prefab = request.GetAsset<GameObject>();

        if (prefab != null)
            GameObject.Instantiate(prefab);

        // Calculate and display the elapsed time.
        float elapsedTime = Time.realtimeSinceStartup - startTime;
        Debug.Log(assetName + (prefab == null ? " was not" : " was") + " loaded successfully in " + elapsedTime + " seconds");
    }
}

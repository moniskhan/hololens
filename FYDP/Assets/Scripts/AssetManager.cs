using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;

public class AssetManager : MonoBehaviour
{


    private bool initialized = false;

    List<Object> furnitures = new List<Object>();

    public void InstantiateGameObject(string assetBundleName, string assetName)
    {
        StartCoroutine(InstantiateGameObjectAsync(assetBundleName, assetName));
    }

    public void Start()
    {
    }

    // Initialize the downloading url and AssetBundleManifest object.
    protected IEnumerator Initialize()
    {
        // Don't destroy this gameObject as we depend on it to run the loading script.
        DontDestroyOnLoad(gameObject);

        //string url = "https://dl.dropboxusercontent.com/u/49884199/AssetBundles";
        string url = "https://dl.dropboxusercontent.com/u/49884199/bundle";
        AssetBundleLoader.setAssetBundleUrl(url); 

        string assetBundleName = "AssetBundles";
        // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
        var request = AssetBundleLoader.Initialize(assetBundleName);
        if (request != null)
            yield return StartCoroutine(request);
    }


    public void clearFurnitureAssets()
    {
        foreach (GameObject gObject in furnitures)
        {
            gObject.SetActive(false);
            Destroy(gObject);
        }
        furnitures.Clear();
    }

    protected IEnumerator InstantiateGameObjectAsync(string assetBundleName, string assetName)
    {
        if (!initialized)
        {
            yield return StartCoroutine(Initialize());
            initialized = true;
            Debug.Log("Initialized");
        }

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
        {
            Vector3 infront = new Vector3(0.5f, -0.5f, 2.0f);
            Vector3 position = Camera.main.ViewportToWorldPoint(infront);
            GameObject furnitureFab = GameObject.Instantiate(prefab, position, Quaternion.identity);
            furnitureFab.SetActive(true);
            furnitures.Add(furnitureFab);
        }

        // Calculate and display the elapsed time.
        float elapsedTime = Time.realtimeSinceStartup - startTime;
        Debug.Log(assetName + (prefab == null ? " was not" : " was") + " loaded successfully in " + elapsedTime + " seconds");

    }
}
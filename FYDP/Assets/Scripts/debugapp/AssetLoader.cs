using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    public List<GameObject> chairList = new List<GameObject>();
    public List<GameObject> drawerList = new List<GameObject>();
    public List<GameObject> tableList = new List<GameObject>();
    public List<GameObject> sofaList = new List<GameObject>();
    public List<GameObject> bedList = new List<GameObject>();
    public List<GameObject> storageList = new List<GameObject>();
    public List<GameObject> lightsList = new List<GameObject>();

    bool isRemote = false;
    List<GameObject> furntiureInstances = new List<GameObject>();

    public void onLoadAssetClick(string assetName)
    {
        Debug.Log("Loading asset " + assetName);
        string[] assetParts = assetName.Split(',');
        string bundle = assetParts[0];
        string name = assetParts[1];

        if (isRemote == false)
        {
            loadFromDisk(bundle, name);
        } 
        else
        {
            loadFromRemote(bundle, name);
        }
    }

    public void clearFurniture()
    {
        foreach (GameObject f in furntiureInstances)
        {
            f.SetActive(false);
            Destroy(f);
        }
        furntiureInstances.Clear();
    }

    private void loadFromDisk(string bundle, string name)
    {
        Vector3 infront = new Vector3(0.5f, -0.5f, 2.0f);
        Vector3 position = Camera.main.ViewportToWorldPoint(infront);
        GameObject furniture = findAsset(bundle, name);
        if (furniture != null)
        {
            GameObject furnitureInstance = Instantiate(furniture, position, Quaternion.identity);
            furnitureInstance.SetActive(true);
            furntiureInstances.Add(furnitureInstance);
        }
    }

    private void loadFromRemote(string bundle, string name)
    {
        this.GetComponent<AssetManager>().InstantiateGameObject(bundle, name);
    }

    private GameObject findAsset(string bundle, string asset)
    {
        List<GameObject> bundleList = findBundle(bundle);
        foreach (GameObject gObject in bundleList) {
            if (gObject.name.Equals(asset))
            {
                return gObject;
            }
        }
        Debug.Log("Asset: " + asset + " from bundle: " + bundle + " not found!");
        return null;
    }

    private List<GameObject> findBundle(string bundle)
    {
        switch(bundle)
        {
            case "chairassets":
                return chairList;
            case "drawerassets":
                return drawerList;
            case "tableassets":
                return tableList;
            case "sofaassets":
                return sofaList;
            case "bedassets":
                return bedList;
            case "storageassets":
                return storageList;
            case "lightassets":
                return lightsList;
            default:
                return new List<GameObject>();
        }
    }
}

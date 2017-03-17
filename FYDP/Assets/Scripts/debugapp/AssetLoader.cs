using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    public GameObject spawner;

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
        GameObject furniture = spawner.GetComponent<SpawnList>().findAsset(bundle, name);
        if (furniture != null)
        {
            GameObject furnitureInstance = Instantiate(furniture, position, Quaternion.identity);
            furnitureInstance.AddComponent<TapToPlaceParent>();
            furnitureInstance.SetActive(true);
            furntiureInstances.Add(furnitureInstance);
        }
    }

    private void loadFromRemote(string bundle, string name)
    {
        this.GetComponent<AssetManager>().InstantiateGameObject(bundle, name);
    }

   
}

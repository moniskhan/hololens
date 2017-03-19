using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    public GameObject spawner;

    bool isRemote = false;
    List<GameObject> furntiureInstances = new List<GameObject>();

    public void onLoadAssetClick(string bundle, string name)
    {
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
        if (!isRemote)
        {
            foreach (GameObject f in furntiureInstances)
            {
                f.SetActive(false);
                Destroy(f);
            }
            furntiureInstances.Clear();
        }
        else
        {
            this.GetComponent<AssetManager>().clearFurnitureAssets();
        }

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

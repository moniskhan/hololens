using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    public GameObject spawner;

    public static AssetLoader Instance { get; private set; }

    bool isRemote = false;
    List<GameObject> furntiureInstances = new List<GameObject>();

    public void Start()
    {
        Instance = this;
    }

    public void onLoadAssetClick(string bundle, string name, Vector3 position = default(Vector3), Quaternion angle = default(Quaternion))
    {
        if (isRemote == false)
        {
            loadFromDisk(bundle, name, position, angle);
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

    public void DeleteFurniture(GameObject obj)
    {
        furntiureInstances.Remove(obj);
        Destroy(obj);
    }

    public void ResetAllFocus()
    {
        foreach (GameObject f in furntiureInstances)
        {
            f.SendMessageUpwards("OnRotateStop");
        }
    }

    private void loadFromDisk(string bundle, string name, Vector3 position = default(Vector3), Quaternion angle = default(Quaternion))
    {
        SpawnList spawnlist = spawner.GetComponent<SpawnList>();
        GameObject furniture = spawnlist.findAsset(bundle, name);
        Vector3 infront = new Vector3(0.5f, -0.5f, 2.0f);
        if (position == default(Vector3))
        {
            position = Camera.main.ViewportToWorldPoint(infront);
        }
        if (angle == default(Quaternion))
        {
            angle = Quaternion.identity;
        }
        if (furniture != null)
        {
            GameObject furnitureInstance = Instantiate(furniture, position, angle);
            //furnitureInstance.AddComponent<TapToPlaceParent>();
            furnitureInstance.AddComponent<TapToPlace>();
            furnitureInstance.AddComponent<ChangeFurniture>();
            furnitureInstance.SetActive(true);
            furntiureInstances.Add(furnitureInstance);
            FurnitureMenuItemProperty properties = furnitureInstance.AddComponent<FurnitureMenuItemProperty>();
            properties.furnitureProperty = spawnlist.findAssetProperties(bundle, name);
        }
    }

    private void loadFromRemote(string bundle, string name)
    {
        this.GetComponent<AssetManager>().InstantiateGameObject(bundle, name);
    }

   
}

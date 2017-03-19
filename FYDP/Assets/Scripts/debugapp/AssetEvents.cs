using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetEvents : MonoBehaviour {

    public GameObject assetSpawn;

    public void onFurnitureClick(string id)
    {
        string bundle = "";
        string name = "";
        if (id.Length > 0)
        {
            string[] assetParts = id.Split(',');
            bundle = assetParts[0];
            name = assetParts[1];
        }
        else
        {
            FurnitureProperty properties = gameObject.GetComponent<FurnitureMenuItemProperty>().furnitureProperty;
            bundle = properties.bundle;
            name = properties.assetName;
        }

        assetSpawn.GetComponent<AssetLoader>().onLoadAssetClick(bundle, name);
    }

    public void onFurnitureClear()
    {
        assetSpawn.GetComponent<AssetLoader>().clearFurniture();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetEvents : MonoBehaviour {

    public GameObject assetSpawn;

    public void onFurnitureClick(string id)
    {
        assetSpawn.GetComponent<AssetLoader>().onLoadAssetClick(id);
    }

    public void onFurnitureClear()
    {
        assetSpawn.GetComponent<AssetLoader>().clearFurniture();
    }
}

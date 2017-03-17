using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnList : MonoBehaviour {

    public List<GameObject> chairs;
    public List<GameObject> tables;
    public List<GameObject> sofas;
    public List<GameObject> storage;
    public List<GameObject> drawers;
    public List<GameObject> lights;
    public List<GameObject> beds;

    public GameObject findAsset(string bundle, string asset)
    {
        List<GameObject> bundleList = findBundle(bundle);
        foreach (GameObject gObject in bundleList)
        {
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

        switch (bundle)
        {
            case "chairassets":
                return chairs;
            case "drawerassets":
                return drawers;
            case "tableassets":
                return tables;
            case "sofaassets":
                return sofas;
            case "bedassets":
                return beds;
            case "storageassets":
                return storage;
            case "lightassets":
                return lights;
            default:
                return new List<GameObject>();
        }
    }
}

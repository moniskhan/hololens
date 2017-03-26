using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeFurniture : MonoBehaviour {

    public GameObject furniture;
    public static Dictionary<string, List<string>> furnitureNames = new Dictionary<string, List<string>>();

    void OnHoldStarted()
    {
        Vector3 position = GazeGestureManager.Instance.FocusedObject.transform.parent.position;
        Quaternion angle = GazeGestureManager.Instance.FocusedObject.transform.parent.rotation;
        print("hold started");

        FurnitureProperty property = GazeGestureManager.Instance.FocusedObject.transform.root.GetComponent<FurnitureMenuItemProperty>().furnitureProperty;

        AssetLoader.Instance.DeleteFurniture(GazeGestureManager.Instance.FocusedObject.transform.parent.gameObject);
        AssetLoader.Instance.onLoadAssetClick(property.bundle, getNextFurnitureName(property.bundle, property.assetName), position, angle);
    }

    // Use this for initialization
    public void Start()
    {
        if(furnitureNames.Count == 0)
        {
            List<string> chairNames = new List<string>();
            List<string> tableNames = new List<string>();
            List<string> sofaNames = new List<string>();
            List<string> storageNames = new List<string>();
            List<string> drawerNames = new List<string>();
            List<string> lightNames = new List<string>();
            List<string> bedNames = new List<string>();
            List<string> otherNames = new List<string>();
            List<string> paintNames = new List<string>();

            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.CHAIR_DICTIONARY)
            {
                chairNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.TABLE_DICTIONARY)
            {
                tableNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.DRAWER_DICTIONARY)
            {
                drawerNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.SOFA_DICTIONARY)
            {
                sofaNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.BED_DICTIONARY)
            {
                bedNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.STORAGE_DICTIONARY)
            {
                storageNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.LIGHT_DICTIONARY)
            {
                lightNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.OTHER_DICTIONARY)
            {
                otherNames.Add(entry.Key);
            }
            foreach (KeyValuePair<string, FurnitureProperty> entry in SpawnList.PAINTS_DICTIONARY)
            {
                paintNames.Add(entry.Key);
            }
            furnitureNames.Add("chairassets", chairNames);
            furnitureNames.Add("drawerassets", drawerNames);
            furnitureNames.Add("tableassets", tableNames);
            furnitureNames.Add("sofaassets", sofaNames);
            furnitureNames.Add("bedassets", bedNames);
            furnitureNames.Add("storageassets", storageNames);
            furnitureNames.Add("lightassets", lightNames);
            furnitureNames.Add("otherassets", otherNames);
            furnitureNames.Add("paintsassets", paintNames);
        }
    }

    public string getNextFurnitureName(string bundle, string name)
    {
        List<string> names = furnitureNames[bundle];
        int index = names.FindIndex(n => n == name);
        if (index + 1 == names.Count)
        {
            return names[0];
        }
        else
        {
            return names[index + 1];
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}

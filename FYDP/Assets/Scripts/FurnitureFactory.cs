using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurnitureFactory : MonoBehaviour
{

    public static FurnitureFactory Instance { get; private set; }

    public GameObject furniture;
    Dictionary<string, GameObject> avaliableObjects = new Dictionary<string, GameObject>();
    List<Object> furnitures = new List<Object>();

    public FurnitureMapping details;
    AssetManager assetManager;

    public void CreateFurniture(string furniture_name, Vector3 position = default(Vector3), Quaternion angle = default(Quaternion))
    {
        if (FurnitureConstants.FETCH_MODELS && FurnitureConstants.FURNITURE_MAP.ContainsKey(furniture_name))
        {
            if (assetManager == null)
                assetManager = gameObject.AddComponent<AssetManager>() as AssetManager;
            FurnitureMetadata metadata = FurnitureConstants.FURNITURE_MAP[furniture_name];
            assetManager.InstantiateGameObject(metadata.bundle, metadata.name);
        }
        else
        {
            Vector3 infront;
            if (position == default(Vector3))
            {
                infront = new Vector3(0.5f, -0.5f, 2.0f);
                position = Camera.main.ViewportToWorldPoint(infront);
            }
            if (angle == default(Quaternion))
            {
                angle = Quaternion.identity;
            }
            furniture = avaliableObjects[furniture_name];
            GameObject temp = (GameObject)Instantiate(furniture, position, angle);
            temp.SetActive(true);
            furnitures.Add(temp);
        }
        
    }

    public void furnitureCreation(string name)
    {
        CreateFurniture(name);
    }

    public void ResetAllFocus()
    {
        foreach (GameObject f in furnitures)
        {
            f.SendMessageUpwards("OnRotateStop");
        }
    }

    void ClearAll()
    {
        if (assetManager && FurnitureConstants.FETCH_MODELS)
        {
            assetManager.clearFurnitureAssets();
        }

        foreach (GameObject f in furnitures)
        {
            f.SetActive(false);
            Destroy(f);
        }
        furnitures.Clear();
    }

    public void DeleteFurniture(GameObject obj)
    {
        furnitures.Remove(obj);
        Destroy(obj);
    }

    void Start()
    {
        details = new FurnitureMapping();
        foreach(var name in details.furnitureIds)
        {
            furniture = GameObject.Find(name);
            avaliableObjects[name] = furniture;
            furniture.SetActive(false);
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

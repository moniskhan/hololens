using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurnitureFactory : MonoBehaviour
{

    public static FurnitureFactory Instance { get; private set; }

    public GameObject furniture;
    Dictionary<string, GameObject> avaliableObjects = new Dictionary<string, GameObject>();
    List<Object> furnitures = new List<Object>();

    public string basicTable = "BasicTable", woodenChair = "WoodenChair", modernSofa = "ModernSofa", woodenChair2 = "WoodenChair2",
        deskLamp = "DeskLamp", roundLamp = "RoundLamp", woodenTable = "WoodenTable", r2d2 = "R2D2", basicWoodTable = "BasicWoodTable",
        wallLight = "light_wall", ceilingLight = "light_ceiling";
    List<string> furnitureNames;

    FurnitureOBJImporter furnitureImporter;
    bool fetchRemoteModel = false;
    Dictionary<string, string> furnitureNameToModelMap = new Dictionary<string, string>
    {
        // place holder models
        { "WoodenTable", "https://dl.dropboxusercontent.com/u/49884199/furniture/table/table2/Table2.obj" },
        { "BasicTable", "https://dl.dropboxusercontent.com/u/49884199/furniture/table/table3/Desk.obj" },
        { "ModernSofa", "https://dl.dropboxusercontent.com/u/49884199/furniture/table/table4/t3.obj" }
    };
    public void CreateFurniture(string furniture_name, Vector3 position = default(Vector3), Quaternion angle = default(Quaternion))
    {
        
        if (fetchRemoteModel && furnitureNameToModelMap.ContainsKey(furniture_name))
        {
            if (furnitureImporter == null)
                furnitureImporter = gameObject.AddComponent<FurnitureOBJImporter>() as FurnitureOBJImporter;
            furnitureImporter.LoadOBJ(furnitureNameToModelMap[furniture_name]);
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

    void ClearAll()
    {
        if (fetchRemoteModel)
        {
            furnitureImporter.clearFurniture();
        }
        else
        {
            foreach (GameObject f in furnitures)
            {
                f.SetActive(false);
                Destroy(f);
            }
            furnitures.Clear();
        }
    }

    void Start()
    {
        furnitureNames = new List<string>() { basicTable, woodenChair, modernSofa, woodenChair2, deskLamp, roundLamp, woodenTable, r2d2, basicWoodTable, wallLight, ceilingLight };
        foreach(var name in furnitureNames)
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

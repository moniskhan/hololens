using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurnitureFactory : MonoBehaviour {

    public GameObject furniture;

    List<Object> furnitures = new List<Object>();
    public static FurnitureFactory Instance { get; private set; }

    public void CreateFurniture(string furniture_name, Vector3 position = default(Vector3), Quaternion angle = default(Quaternion))
    {
        Vector3 infront;
        if(position == default(Vector3))
        {
            infront = new Vector3(0.5f, -0.5f, 2.0f);
            position = Camera.main.ViewportToWorldPoint(infront);
        }
        if(angle == default(Quaternion))
        {
            angle = Quaternion.identity;
        }
        furniture = GameObject.Find(furniture_name);
        furnitures.Add(Instantiate(furniture, position, angle));
    }
    void CreateBasicTable()
    {
        CreateFurniture("BasicTable");
    }

    void CreateWoodenChair()
    {
        CreateFurniture("WoodenChair");
    }

    void CreateModernSofa()
    {
        CreateFurniture("ModernSofa");
    }

    void CreateWoodenChair2()
    {
        CreateFurniture("WoodenChair2");
    }

    void CreateDeskLamp()
    {
        CreateFurniture("DeskLamp");
    }

    void CreateRoundLamp()
    {
        CreateFurniture("RoundLamp");
    }

    void CreateWoodenTable()
    {
        CreateFurniture("WoodenTable");
    }

    void CreateR2D2()
    {
        CreateFurniture("R2D2");
    }


    void ClearAll()
    {
        foreach (Object f in furnitures )
        {
            Destroy(f);
        }
        furnitures.Clear();
    }


    void Start () {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

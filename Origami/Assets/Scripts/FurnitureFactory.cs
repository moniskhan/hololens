using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurnitureFactory : MonoBehaviour {

    public GameObject furniture;
    Vector3 infront;
    Vector3 point;
    List<Object> furnitures = new List<Object>();

    void CreateFurniture(string furniture_name)
    {
        infront = new Vector3(0.5f, -0.5f, 2.0f);
        point = Camera.main.ViewportToWorldPoint(infront);
        furniture = GameObject.Find(furniture_name);
        furnitures.Add(Instantiate(furniture, point, Quaternion.identity));
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
	
    void ClearAll()
    {
        foreach (Object f in furnitures )
        {
            Destroy(f);
        }
        furnitures.Clear();
    }


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class ChangeFurniture : MonoBehaviour {

    public GameObject furniture;
    void OnHoldStarted()
    {
        Vector3 position = GazeGestureManager.Instance.FocusedObject.transform.parent.position;
        Quaternion angle = GazeGestureManager.Instance.FocusedObject.transform.parent.rotation;
        print("hold started");
        print(GazeGestureManager.Instance.FocusedObject.name);
        if (GazeGestureManager.Instance.FocusedObject.name == "basic_table")
        {
            FurnitureFactory.Instance.DeleteFurniture(GazeGestureManager.Instance.FocusedObject.transform.parent.gameObject);
            FurnitureFactory.Instance.CreateFurniture(FurnitureFactory.Instance.basicWoodTable, position, angle);
        }
        if (GazeGestureManager.Instance.FocusedObject.name == "basic_table_wood")
        {
            FurnitureFactory.Instance.DeleteFurniture(GazeGestureManager.Instance.FocusedObject.transform.parent.gameObject);
            FurnitureFactory.Instance.CreateFurniture(FurnitureFactory.Instance.basicTable, position, angle);
        }


    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

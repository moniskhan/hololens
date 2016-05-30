using UnityEngine;
using System.Collections;

public class ChangeFurniture : MonoBehaviour {

    public GameObject furniture;
    void OnHoldStarted()
    {
        Vector3 position = GazeGestureManager.Instance.FocusedObject.transform.parent.position;
        Quaternion angle = GazeGestureManager.Instance.FocusedObject.transform.parent.rotation;
        print("hold started");
        if (GazeGestureManager.Instance.FocusedObject.name == "basic_table")
        {
            Destroy(GazeGestureManager.Instance.FocusedObject.transform.parent.gameObject);
            FurnitureFactory.Instance.CreateFurniture("WoodenTable", position, angle);
        }
        if (GazeGestureManager.Instance.FocusedObject.name == "table_7103")
        {
            Destroy(GazeGestureManager.Instance.FocusedObject.transform.parent.gameObject);
            FurnitureFactory.Instance.CreateFurniture("BasicTable", position, angle);
        }


    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

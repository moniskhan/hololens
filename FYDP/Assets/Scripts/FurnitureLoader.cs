using UnityEngine;
using System.Collections;

public class FurnitureLoader : MonoBehaviour {
    
    public void LoadFurnitureModel(string path)
    {
        FurnitureOBJImporter importer = gameObject.AddComponent<FurnitureOBJImporter>() as FurnitureOBJImporter;
        importer.LoadOBJ("https://dl.dropboxusercontent.com/u/49884199/furniture/table/table1/Table.obj");
    }
}

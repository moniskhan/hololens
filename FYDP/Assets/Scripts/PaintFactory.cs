using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintFactory : MonoBehaviour
{

    public static PaintFactory Instance { get; private set; }

    public void paintWalls(string name)
    {

        if(name == "clear")
        {
           // HoloToolkit.Unity.SpatialMappingManager.DrawVisualMeshes = false;
        } else
        {

        }
    }


    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

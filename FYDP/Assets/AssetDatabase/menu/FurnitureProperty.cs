using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FurnitureProperty {

    public enum FurnitureType
    {
        GROUND_PLACEABLE, CEILING_PLACEABLE, WALL_PLACEABLE
    };

    public string bundle;
    public string assetName;

    public FurnitureType furnitureType;
}

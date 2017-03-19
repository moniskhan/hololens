using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsPage : MonoBehaviour {

    public GameObject title;
    public GameObject description;
    public GameObject picture;
    public GameObject okBtn;

	public void populate(FurnitureMenuItemProperty item)
    {
        okBtn.GetComponent<FurnitureMenuItemProperty>().furnitureProperty = item.furnitureProperty;
        title.GetComponent<Text>().text = item.furnitureProperty.assetName;
        description.GetComponent<Text>().text = item.furnitureProperty.bundle;
    }

}

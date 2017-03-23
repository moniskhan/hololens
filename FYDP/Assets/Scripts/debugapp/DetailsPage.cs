using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsPage : MonoBehaviour {

    public GameObject title;
    public GameObject description;
    public GameObject picture;
    public GameObject okBtn;
    public GameObject spawner;

	public void populate(FurnitureMenuItemProperty item)
    {
        okBtn.GetComponent<FurnitureMenuItemProperty>().furnitureProperty = item.furnitureProperty;
        title.GetComponent<Text>().text = item.furnitureProperty.title;
        description.GetComponent<Text>().text = item.furnitureProperty.description;
        picture.GetComponent<Image>().sprite = spawner.GetComponent<SpawnList>().findAssetIcon(item.furnitureProperty.bundle, item.index);
    }

}

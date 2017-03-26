using HoloToolkit.Unity;
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
    public TextToSpeechManager textToSpeechManager = null;

	public void populate(FurnitureMenuItemProperty item)
    {
        okBtn.GetComponent<FurnitureMenuItemProperty>().furnitureProperty = item.furnitureProperty;
        title.GetComponent<Text>().text = item.furnitureProperty.title;
        description.GetComponent<Text>().text = item.furnitureProperty.description;
        if (!item.furnitureProperty.bundle.Contains("paint"))
        {
            picture.GetComponent<Image>().sprite = spawner.GetComponent<SpawnList>().findAssetIcon(item.furnitureProperty.bundle, item.index);
            picture.GetComponent<Image>().material = null;
        }
        else
        {
            picture.GetComponent<Image>().material = spawner.GetComponent<SpawnList>().findPaintIcon(item.index);
            picture.GetComponent<Image>().sprite = null;
        }
        dictate();
    }

    void dictate()
    {
        textToSpeechManager = Camera.main.GetComponentInChildren<TextToSpeechManager>();
        string msg = "Confirm to place a hologram in your environment... Then select the hologram by air tapping and move it with your gaze... Tap and hold a hologram to change to a different object... Rotate a hologram by holding and dragging left or right";

        if (textToSpeechManager != null && !textToSpeechManager.IsSpeaking())
        {
            Debug.Log("Dictating Model Instructions");
            textToSpeechManager.SpeakText(msg);
        }
        else if (textToSpeechManager != null && textToSpeechManager.IsSpeaking())
        {
            textToSpeechManager.StopSpeaking();
        }
    }

}

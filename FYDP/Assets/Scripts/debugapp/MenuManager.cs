using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.VR.WSA.Input;
using UnityEngine.EventSystems;

public class MenuManager : Singleton<MenuManager> {

    public enum MenuPanel { Main=0, Category=1, Details=2 }
    MenuPanel activeMenuType;

    public bool isShowing;

    public GameObject mainMenu;
    public GameObject categoryMenu;
    public GameObject detailsMenu;
    GameObject activeMenu;

    GestureRecognizer recognizer;
    float lastTime;

    string prevCategory;

	void Start () {
        mainMenu.SetActive(true);
        categoryMenu.SetActive(false);
        detailsMenu.SetActive(false);
        activeMenuType = MenuPanel.Main;
        activeMenu = mainMenu;
        isShowing = true;
        lastTime = Time.time;
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (Time.time - lastTime < 1)
            {
                Debug.Log("TappedEvent triggered");
                if(!GazeGestureManager.Instance.placingActive)
                {
                    ToggleMenu();
                }
                lastTime = 0;
            }
            else
            {
                lastTime = (float)Time.time;
            }
        };
        positionMenu();
        recognizer.StartCapturingGestures();
	}
	
    public void ToggleMenu()
    {
        isShowing = !isShowing;
        activeMenu.SetActive(isShowing);
        Debug.Log("isShowing " + isShowing);
        if (isShowing)
        {
            positionMenu();
        }
    }

    void positionMenu()
    {
        Vector3 point = Camera.main.transform.position + Camera.main.transform.forward * 2;
        activeMenu.transform.position = point;

        // Rotate this object's parent object to face the user.
        Quaternion toQuat = Camera.main.transform.localRotation;
        toQuat.x = 0;
        toQuat.z = 0;
        activeMenu.transform.rotation = toQuat;
    }

    public void SwitchMenu(int newMenuType)
    {
        SwitchMenu((MenuPanel)newMenuType);
    }

    public void SwitchMenu(MenuPanel newMenuType)
    {
        if (activeMenuType != newMenuType && isShowing)
        {
            // Get previous position
            Vector3 oldPosition = activeMenu.transform.position;
            Quaternion oldRotation1 = activeMenu.transform.rotation;
            Quaternion oldRotation = oldRotation1;
            oldRotation.x = 0;
            oldRotation.z = 0;
            activeMenu.SetActive(false);

            if (newMenuType == MenuPanel.Main)
                activeMenu = mainMenu;
            else if (newMenuType == MenuPanel.Category)
                activeMenu = categoryMenu;
            else if (newMenuType == MenuPanel.Details)
                activeMenu = detailsMenu;
            activeMenu.SetActive(true);
            activeMenu.transform.position = oldPosition;
            activeMenu.transform.rotation = oldRotation;
            activeMenuType = newMenuType;
        }
    }

    public void SwitchToCategoryMenu(string category)
    {
        prevCategory = category;
        // switch ui
        SwitchMenu(MenuPanel.Category);
        // call load content
        CategoryMenuLoader loader = activeMenu.transform.Find("Canvas").GetComponent<CategoryMenuLoader>();
        loader.LoadList(category);
    }

    public void SwitchBackToCategoryMenu()
    {
        SwitchToCategoryMenu(prevCategory);
    }

    public void SwitchToDetailsMenu()
    {
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        FurnitureMenuItemProperty furnitureProperty = selectedButton.GetComponent<FurnitureMenuItemProperty>();
        // switch ui
        SwitchMenu(MenuPanel.Details);
        // populate content
        DetailsPage page = activeMenu.transform.Find("Canvas").GetComponent<DetailsPage>();
        page.populate(furnitureProperty);
    }

    public void CancelClick()
    {
        lastTime = 0;
    }

	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            ToggleMenu();
        }
	}
}

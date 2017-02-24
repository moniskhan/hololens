using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;
using UnityEngine.UI;

public class ShowSecondaryMenu : MonoBehaviour
{
    public static ShowSecondaryMenu Instance { get; private set; }
    public Transform menuObject;
    public GameObject menu; // Assign in inspector
    public string selectedItem;
    public bool isShowing;
    private GameObject image;
    private Text title;
    private Text description;

    void Start()
    {
        Instance = this;
        image = GameObject.Find("Secondary Menu Image");
        description = GameObject.Find("Secondary Menu Description").GetComponent<Text>();
        title = GameObject.Find("Secondary Menu Name").GetComponent<Text>();


        CloseMenu();
    }

    public void OpenMenu(string furniture)
    {
        isShowing = true;
        selectedItem = furniture;
        menuObject = transform.Find("Secondary Canvas");
        menu = menuObject.gameObject;
        menu.SetActive(true);

        if (ShowMenu.Instance.isShowing)
        {
            var point = ShowMenu.Instance.menuObject.position;
            menuObject.position = point;
        }
        else
        {
            Vector3 infront = new Vector3(0.5f, 0.5f, 2.0f);
            var point = Camera.main.ViewportToWorldPoint(infront);
            menuObject.position = point;
        }

        // Rotate this object's parent object to face the user.
        Quaternion toQuat = Camera.main.transform.localRotation;
        toQuat.x = 0;
        toQuat.z = 0;
        menuObject.rotation = toQuat;

        if (ShowMenu.Instance.isShowing)
        {
            transform.Translate(Vector3.right * 0.8f, Camera.main.transform);
        }

        updateSecondaryMenu();
    }

    public void CloseMenu()
    {
        isShowing = false;
        menuObject = transform.Find("Secondary Canvas");
        menu = menuObject.gameObject;
        menu.SetActive(false);
    }

    void updateSecondaryMenu()
    {
        title.text = selectedItem;
        description.text = selectedItem + " description\n This furniture is very nice, you should buy it ;)";
    }

    public void Confirm()
    {
        FurnitureFactory.Instance.CreateFurniture(selectedItem);
    }

    void Update()
    {

    }
}
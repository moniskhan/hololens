using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;
public class ShowMenu : MonoBehaviour
{

    public Transform menuObject;
    public GameObject menu; // Assign in inspector
    private bool isShowing;
   
    GestureRecognizer recognizer;

    float maxDepressionAngle = 10;

    public float lastTime;

    void Start()
    {
        lastTime = Time.time;
        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) => {
            if (Time.time - lastTime < 1)
            {
                ToggleMenu();
                lastTime = 0;  //Clear double click after one is triggered
            }
            else
            {
                lastTime = (float)Time.time;
            }
            };
        recognizer.StartCapturingGestures();
    }

    void ToggleMenu()
    {
        menuObject = transform.Find("Canvas");
        menu = menuObject.gameObject;
        isShowing = !isShowing;
        menu.SetActive(isShowing);
       
        if (isShowing)
        {

            Vector3 infront = new Vector3(0.5f, 0.5f, 2.0f);
            var point = Camera.main.ViewportToWorldPoint(infront);
            menuObject.position = point;

            // Rotate this object's parent object to face the user.
            Quaternion toQuat = Camera.main.transform.localRotation;
            toQuat.x = 0;
            toQuat.z = 0;
            menuObject.rotation = toQuat;
           
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            menu = transform.Find("Menu_Panel").gameObject;
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}
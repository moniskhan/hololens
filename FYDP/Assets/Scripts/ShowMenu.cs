using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;
public class ShowMenu : MonoBehaviour
{
    public static ShowMenu Instance { get; private set; }
    public Transform menuObject;
    public GameObject menu; // Assign in inspector
    public bool isShowing;
   
    GestureRecognizer recognizer;

    float maxDepressionAngle = 10;

    public float lastTime;

    void Start()
    {
        Instance = this;
        isShowing = true;
        lastTime = Time.time;
        menuObject = transform.Find("Canvas");
        menu = menuObject.gameObject;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) => {
            if (Time.time - lastTime < 1)
            {
            //    if(GazeGestureManager.Instance.FocusedObject == null)
            //    {
                    ToggleMenu();
            //    }
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

    public void CancelClick()
    {
        lastTime = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ToggleMenu();
        }
    }
}
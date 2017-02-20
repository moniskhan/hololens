using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    public bool IsNavigating { get; private set; }
    public Vector3 NavigationPosition { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Start()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };

        recognizer.HoldStartedEvent += (source, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnHoldStarted");
            }
        };

        recognizer.NavigationStartedEvent += NavigationStartedEvent;
        recognizer.NavigationUpdatedEvent += NavigationUpdatedEvent;
        recognizer.NavigationCompletedEvent += NavigationCompletedEvent;
        recognizer.NavigationCanceledEvent += NavigationCompletedEvent;

        recognizer.StartCapturingGestures();
    }

    private void NavigationStartedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    {
        print("Navigation Started");

        if (FocusedObject != null)
        {
            FurnitureFactory.Instance.ResetAllFocus();
            FocusedObject.SendMessageUpwards("OnRotateStart");
        }

        IsNavigating = true;

        NavigationPosition = relativePosition;
    }


    private void NavigationUpdatedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    {
        print("Navigation Updated");
        IsNavigating = true;
        
        NavigationPosition = relativePosition;
    }

    private void NavigationCompletedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    {
        print("Navigation Completed");
        if (FocusedObject != null)
        {
            FocusedObject.SendMessageUpwards("OnRotateStop");
        }
        IsNavigating = false;
    }

    private void NavigationCanceledEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    {
        print("Navigation Canceled");
        if (FocusedObject != null)
        {
            FocusedObject.SendMessageUpwards("OnRotateStop");
        }
        IsNavigating = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
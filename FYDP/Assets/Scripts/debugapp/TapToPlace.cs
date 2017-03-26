using UnityEngine;

public class TapToPlace : MonoBehaviour
{
    bool placing = false;
    bool rotating = false;
    float minDepressionAngle = 30;
    float minAscensionAngle = 30;
    float RotationSensitivity = 180f;
    Vector3 startingRotationAngle;

    void Start()
    {
    }

    void OnSelect()
    {
        MenuManager.Instance.CancelClick();
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;
        if (placing)
        {
            GazeGestureManager.Instance.PlacingObject = this;
        }
        GazeGestureManager.Instance.placingActive = placing;
    }

    void onFurnitureDrop()
    {
        placing = false;
        GazeGestureManager.Instance.placingActive = false;
    }

    void OnRotateStart()
    {
        MenuManager.Instance.CancelClick();
        startingRotationAngle = GazeGestureManager.Instance.FocusedObject.transform.parent.transform.localEulerAngles;
        rotating = true;
    }

    void OnRotateStop()
    {
        rotating = false;
    }

    bool isWall()
    {
        return this.GetComponent<FurnitureMenuItemProperty>().furnitureProperty.furnitureType == FurnitureProperty.FurnitureType.WALL_PLACEABLE;
    }

    bool isCeiling()
    {
        return this.GetComponent<FurnitureMenuItemProperty>().furnitureProperty.furnitureType == FurnitureProperty.FurnitureType.CEILING_PLACEABLE;
    }


    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;
            bool belowGround = false;

            Vector3 horizontalDirection = new Vector3(gazeDirection.x, 0, gazeDirection.z);
            float angleFromHor = Vector3.Angle(gazeDirection, horizontalDirection);
            if (gazeDirection.y < 0)
            {
                belowGround = true;
            }
            //print(angleFromHor);
            //print(belowGround);

            if (!isWall() && !isCeiling() && (angleFromHor < minDepressionAngle || !belowGround))
            {
                float horizontalLength = horizontalDirection.magnitude;
                float adjustedY = Mathf.Tan(minDepressionAngle / 180 * Mathf.PI) * horizontalLength;
                gazeDirection.y = -Mathf.Abs(adjustedY);
            }
            else if (isCeiling() && (angleFromHor < minAscensionAngle || belowGround))
            {
                float horizontalLength = horizontalDirection.magnitude;
                float adjustedY = Mathf.Tan(minAscensionAngle / 180 * Mathf.PI) * horizontalLength;
                gazeDirection.y = Mathf.Abs(adjustedY);
            }
            else if (isWall() && ((angleFromHor > 70 && belowGround) || (angleFromHor > minAscensionAngle && !belowGround)))
            {
                if (belowGround)
                {
                    float horizontalLength = horizontalDirection.magnitude;
                    float adjustedY = Mathf.Tan(70 / 180 * Mathf.PI) * horizontalLength;
                    gazeDirection.y = -adjustedY;
                }
                else
                {
                    float horizontalLength = horizontalDirection.magnitude;
                    float adjustedY = Mathf.Tan(minAscensionAngle / 180 * Mathf.PI) * horizontalLength;
                    gazeDirection.y = adjustedY;
                }
            }

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                this.transform.position = hitInfo.point;

                /*
                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;

                toQuat.x = 0;
                toQuat.z = 0;
                if (GazeGestureManager.Instance.IsNavigating)
                {
                    float rotationFactor;

                    rotationFactor = GazeGestureManager.Instance.NavigationPosition.x * RotationSensitivity;
  
                    toQuat.y = -1 * rotationFactor;

                }
                this.transform.rotation = toQuat;
                */
            }

        }
        if (rotating && GazeGestureManager.Instance.IsNavigating)
        {
            Vector3 toQuat = GazeGestureManager.Instance.FocusedObject.transform.parent.transform.localEulerAngles;
            float rotationFactor;
            rotationFactor = GazeGestureManager.Instance.NavigationPosition.x * RotationSensitivity;
            this.transform.rotation = Quaternion.Euler(toQuat.x, startingRotationAngle.y - 1 * rotationFactor, toQuat.z);
        }
    }
}
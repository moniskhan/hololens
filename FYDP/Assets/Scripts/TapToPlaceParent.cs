using UnityEngine;

public class TapToPlaceParent : MonoBehaviour
{
    bool placing = false;
    bool rotating = false;
    float minDepressionAngle = 30;
    float minAscensionAngle = 30;
    float RotationSensitivity = 1.2f;
//private MeshRenderer meshRenderer;

    void Start()
    {
   //     meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        
    }

    void OnRotateStart()
    {
        rotating = true;
    }

    void OnRotateStop()
    {
        rotating = false;
    }

    bool isWall()
    {
        return this.name.Contains("wall");
    }

    bool isCeiling()
    {
        return this.name.Contains("ceiling");
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
            if(gazeDirection.y < 0)
            {
                belowGround = true;
            }
            print(angleFromHor);

            print(belowGround);

            if(!isWall() && !isCeiling() && (angleFromHor < minDepressionAngle || !belowGround))
            {
                float horizontalLength = horizontalDirection.magnitude;
                float adjustedY = Mathf.Tan(minDepressionAngle/180*Mathf.PI) * horizontalLength;
                gazeDirection.y = - Mathf.Abs(adjustedY);
            } 
            else if(isCeiling() && (angleFromHor < minAscensionAngle|| belowGround))
            {
                float horizontalLength = horizontalDirection.magnitude;
                float adjustedY = Mathf.Tan(minAscensionAngle / 180 * Mathf.PI) * horizontalLength;
                gazeDirection.y = Mathf.Abs(adjustedY);
            }
            else if(isWall() && ((angleFromHor > 70  && belowGround) || ( angleFromHor > minAscensionAngle && !belowGround))) {
                if (belowGround)
                {
                    float horizontalLength = horizontalDirection.magnitude;
                    float adjustedY = Mathf.Tan(70 / 180 * Mathf.PI) * horizontalLength;
                    gazeDirection.y = -adjustedY;
                } else
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
            Quaternion toQuat = Camera.main.transform.localRotation;

            toQuat.x = 0;
            toQuat.z = 0;
            float rotationFactor;
            rotationFactor = GazeGestureManager.Instance.NavigationPosition.x / RotationSensitivity;
            toQuat.y = -1 * rotationFactor;

            this.transform.rotation = toQuat;
        }
    }
}
using UnityEngine;

public class TapToPlaceParent : MonoBehaviour
{
    bool placing = false;
    float minDepressionAngle = 30;

//private MeshRenderer meshRenderer;

    void Start()
    {
   //     meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = true;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh. Disabled for emulator 
        //else
      //  {
    //        SpatialMapping.Instance.DrawVisualMeshes = false;
    //    }
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
            Vector3 horizontalDirection = new Vector3(gazeDirection.x, 0, gazeDirection.z);
            float depressionAngle = Vector3.Angle(gazeDirection, horizontalDirection);
            print(depressionAngle);
            if(depressionAngle < minDepressionAngle)
            {
                float horizontalLength = horizontalDirection.magnitude;
                float adjustedY = Mathf.Tan(minDepressionAngle/180*Mathf.PI) * horizontalLength;
                gazeDirection.y = - adjustedY;
            }
            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                this.transform.position = hitInfo.point;
                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;

                this.transform.rotation = toQuat;
            }
        }
    }
}
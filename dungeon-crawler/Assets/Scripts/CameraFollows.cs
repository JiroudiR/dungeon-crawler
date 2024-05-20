using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public bool CameraIsFollowing;
    public bool followX;
    public bool followY;
    public float smoothFactor;

    public Vector3 boundaryMinimum;
    public Vector3 boundaryMaximum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (CameraIsFollowing)
        {
            FollowTarget();
        }
    }
    void FollowTarget()
    {
        Vector3 cameraPosition = Target.position + Offset;

        Vector3 boundPosition = new Vector3(Mathf.Clamp(cameraPosition.x, boundaryMinimum.x, boundaryMaximum.x),
        Mathf.Clamp(cameraPosition.y, boundaryMinimum.y, boundaryMaximum.y),
        Mathf.Clamp(cameraPosition.z, boundaryMinimum.z, boundaryMaximum.z));

        Vector3 NewTargetPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);

        if (followX)
        {
            transform.position = new Vector3 (NewTargetPosition.x, transform.position.y, transform.position.z);
        }
        if (followY)
        {
            transform.position = new Vector3(transform.position.x, NewTargetPosition.y, transform.position.z);
        }
    }
}

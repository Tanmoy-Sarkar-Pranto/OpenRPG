using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform valdyr;
    [SerializeField] float cameraSmoothing;
    public Vector2 maxCameraPosition;
    public Vector2 minCameraPosition;
    void Start()
    {
        transform.position = new Vector3(valdyr.position.x, valdyr.position.y, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position!=valdyr.transform.position)
        {
            Vector3 targetPosition = new Vector3(valdyr.position.x, valdyr.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minCameraPosition.x,maxCameraPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minCameraPosition.y, maxCameraPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing);
        }
    }
}

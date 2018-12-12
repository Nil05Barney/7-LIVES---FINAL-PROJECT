using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform lookAt;

    private bool smooth = true;
    private float smoothSpeed = 1f;
    private Vector3 offset = new Vector3(1f, 3f, -14);
    private Vector3 zoom = new Vector3(1f, 3f, -10);

    // Update is called once per frame
    public void Update()
    {
        Vector3 desiredPosition = lookAt.transform.position + offset;

        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }

        else
        {
            transform.position = desiredPosition;
        }
    }

    public void CameraNormal()
    {
        Vector3 desiredPosition = lookAt.transform.position + offset;

        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }

        else
        {
            transform.position = desiredPosition;
        }


    }

    public void CameraSliding()
    {
        Vector3 desiredPosition = lookAt.transform.position + zoom;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    }

    public void CameraDamage()
    {
        Vector3 desiredPosition = lookAt.transform.position + zoom;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, -smoothSpeed);

    }
}

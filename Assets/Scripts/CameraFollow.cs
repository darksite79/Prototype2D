using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public float minX = -Mathf.Infinity;
    public float maxX = Mathf.Infinity;

    private float fixedY;
    private float fixedZ;

    void Start()
    {
        if (target != null)
        {
            fixedY = transform.position.y;
            fixedZ = transform.position.z;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
        Vector3 desiredPosition = new Vector3(clampedX, fixedY, fixedZ);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

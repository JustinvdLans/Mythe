using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    float minDistance = 1.0f;
    float maxDistance = 4.0f;
    float smooth = 10.0f;
    
    Vector3 Dollydir;

    public Vector3 dollyDirAdjusted;
    [SerializeField]
    float distance;

   

    void Awake()
    {
        Dollydir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(Dollydir * maxDistance);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        } else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, Dollydir * distance, Time.deltaTime * smooth);
    }
}

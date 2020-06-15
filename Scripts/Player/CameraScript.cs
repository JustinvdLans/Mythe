using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float sensitivity;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        offset = Quaternion.AngleAxis(horizontal * sensitivity, Vector3.up) * offset;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(new Vector3(target.position.x, target.position.y + 4, target.position.z));  
        
    }
}

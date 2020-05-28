using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity;

    [SerializeField]
    Transform player;

    Rigidbody rb;


    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;

        rotPlayer.x -= rotAmountY;
        rotPlayer.y += rotAmountX;

        player.rotation = Quaternion.Euler(rotPlayer);

    }
}
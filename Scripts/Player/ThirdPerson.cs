using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPerson : MonoBehaviour
{


    [SerializeField]
    float mouseSensitivity;


    [SerializeField]
    Camera thirdPerson;


    [SerializeField]
    Transform playerBody;

    float xAxisClamp;


    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Checkts if it is thirdperson or firstperson camera
    void Update()
    {
        ThirdPersonCamera();
    }



    //Thirdperson camera settings
    void ThirdPersonCamera()
    {
        thirdPerson.enabled = true;

        float mouseX = Input.GetAxis("Mouse X");


        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        playerBody.Rotate(Vector3.up * mouseX);

    }


    //Better Clamp First person camera
    void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    // Toggle tekst Lower left corner
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 250, 1000, 200), "Press F to toggle view");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPerson : MonoBehaviour
{

    [SerializeField]
    float mouseSensitivity;


    [SerializeField]
    Camera thirdPerson;


    bool thirdPersonActive = false;


    [SerializeField]
    Camera firstPerson;

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

    void Update()
    {
        if (thirdPersonActive)
        {
            ThirdPersonCamera();
        } else
        {
            FirstPersonCamera();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            thirdPersonActive = !thirdPersonActive;
        }
    }




    void ThirdPersonCamera()
    {
        thirdPerson.enabled = true;
        firstPerson.enabled = false;

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


    void FirstPersonCamera()
    {
        thirdPerson.enabled = false;
        firstPerson.enabled = true;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 250, 1000, 200), "Press F to toggle view");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPerson : MonoBehaviour
{

    [SerializeField]
    Camera firstPerson;

    [SerializeField]
    Camera thirdPerson;

    bool thirdPersonActive = false;

    void Update()
    {
        if (thirdPersonActive)
        {
            thirdPerson.enabled = true;
            firstPerson.enabled = false;
        } else
        {
            thirdPerson.enabled = false;
            firstPerson.enabled = true;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            thirdPersonActive = !thirdPersonActive;
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 250, 1000, 200), "Press F to toggle view");
    }
}

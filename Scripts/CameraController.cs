using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform[] views;
    [SerializeField]float transitionSpeed;
    public Transform currentView;
    
    [SerializeField]GameObject cannonsLeft;
    [SerializeField]GameObject cannonsRight;


    void Start()
    {
        currentView = views[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentView = views[0];
            cannonsLeft.SetActive(true);
            cannonsRight.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentView = views[1];
            cannonsLeft.SetActive(true);
            cannonsRight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentView = views[2];
            cannonsLeft.SetActive(false);
            cannonsRight.SetActive(true);
        }
    }


    void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

         Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;
    }
}
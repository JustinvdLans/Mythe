using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCamera : MonoBehaviour
{

  /*  public Transform[] views;
    [SerializeField] float transitionSpeed;
    public Transform currentView;   */

    [SerializeField] GameObject cannonsLeft;
    [SerializeField] GameObject cannonsRight;


    void Start()
    {
       // currentView = views[0];
    }

    void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cannonsLeft.GetComponentInChildren<CannonShoot>().enabled = false;
            cannonsRight.GetComponentInChildren<CannonShoot>().enabled = false;
        }   */

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        //    cannonsLeft.GetComponentInChildren<CannonShoot>().enabled = true;
        //    cannonsRight.GetComponentInChildren<CannonShoot>().enabled = false;

            cannonsLeft.SetActive(true);
            cannonsRight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("also working");
        //    cannonsLeft.GetComponentInChildren<CannonShoot>().enabled = false;
        //    cannonsRight.GetComponentInChildren<CannonShoot>().enabled = true;

            cannonsLeft.SetActive(false);
            cannonsRight.SetActive(true);
        }
    }


  /*  void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
        Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
        Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;
    }   */
}

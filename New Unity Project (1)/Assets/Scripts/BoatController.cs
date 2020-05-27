using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField]
    private Transform motor;
    [SerializeField]
    private float steerPower = 5f;
    [SerializeField]
    private float power = 2f;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float drag = 0.1f;
    [SerializeField]
    private bool anchored = false;
    private bool steering = false;
    private float steer = 0;

    private Rigidbody rb;
    [SerializeField]
    private Rigidbody playerRb;
    private Quaternion startRotation;

    [SerializeField]
    private GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = motor.localRotation;
    }

    private void Update()
    {
        // sets the force direction to forward
        Vector3 forceDirection = transform.forward;
        // checks if the player is behind the wheel and then is able to turn the right way

            if (Input.GetKey(KeyCode.A))
            {
                steer = -1;
                Debug.Log(steer);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                steer = 1;
                Debug.Log(steer);
            }
            // centers out the ship
            else
            {
                steer = 0;
            }

            // turns the ship
            transform.Rotate(new Vector3(0, steer * steerPower, 0));

      //  transform.Translate(transform.forward * maxSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        // sets the forward to the front
        Vector3 forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        // sets the target velocity to zero
        Vector3 targetVel = Vector3.zero;

        // checks if the ship is anchored and sets the speed properly
        if (!anchored)
           {
             //  PhysicsHelper.ApplyForceToReachVelocity(rb, forward * maxSpeed, power);
               transform.Translate(transform.forward * maxSpeed * Time.deltaTime);
           } 

            else
            {
                rb.velocity = Vector3.zero;
            }  
    }

    // IEnumerator as a time cooldown
 /*   IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }   */

    // checks if the player is behind the wheel and disables the movement when he/she is and pressed G
/*    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.G) && !steering)
        {
            Debug.Log(steering);
            Debug.Log("1");
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(Wait());
            Debug.Log("2");
            steering = true;
            Debug.Log("3");
        }

        else if(Input.GetKeyDown(KeyCode.G) && steering)
        {
            Debug.Log("4");
            Debug.Log("5");
            StartCoroutine(Wait());
            steering = false;
            Debug.Log("6");
        } 
    }   */
}

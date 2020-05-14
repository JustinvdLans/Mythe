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
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = motor.localRotation;
    }

    private void Update()
    {
        Vector3 forceDirection = transform.forward;

        if (steering)
        {
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

            else
            {
                steer = 0;
            }

            transform.Rotate(new Vector3(0, steer * steerPower, 0));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector3 forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        Vector3 targetVel = Vector3.zero;
        //   rb.velocity = Vector3.zero;

     //   rb.AddForceAtPosition(steer * transform.right * steerPower / 100f, motor.position);

        if (!anchored)
           {
               PhysicsHelper.ApplyForceToReachVelocity(rb, forward * maxSpeed, power);
           } 

            else
            {
                rb.velocity = Vector3.zero;
            }  
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("using wheel");
     //   Debug.Log(steering);

        if (Input.GetKeyDown(KeyCode.G) && !steering)
        {
            Debug.Log(steering);
            Debug.Log("1");
            player.GetComponent<PlayerMovement>().enabled = false;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(Wait());
            Debug.Log("2");
            steering = true;
            Debug.Log("3");
        }

        else if(Input.GetKeyDown(KeyCode.G) && steering)
        {
            Debug.Log("4");
            player.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("5");
            StartCoroutine(Wait());
            steering = false;
            Debug.Log("6");
        } 
    }
}

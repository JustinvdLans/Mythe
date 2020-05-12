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

    private Rigidbody rb;
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = motor.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forceDirection = transform.forward;
        float steer = 0;

        if (Input.GetKey(KeyCode.A))
        {
            steer = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            steer = -1;
        }

        rb.AddForceAtPosition(steer * transform.right * steerPower / 100f, motor.position);

        Vector3 forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        Vector3 targetVel = Vector3.zero;

        if (!anchored)
        {
            PhysicsHelper.ApplyForceToReachVelocity(rb, forward * maxSpeed, power);
        }

        else
        {
            rb.velocity = Vector3.zero;
        }  
    }
}

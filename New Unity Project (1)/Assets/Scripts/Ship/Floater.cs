using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float depthBeforeSubmerged = 1f;
    [SerializeField]
    private float displacementAmount = 3f;
    [SerializeField]
    private int floaterCount = 4;
    [SerializeField]
    private float waterDrag = 0.99f;
    [SerializeField]
    private float waterAngularDrag = 0.5f;
    private Vector3 prevVelocity;

    private void FixedUpdate()
    {
        // adds gravity to the object, and instantiates the waveHeight
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.z);

        // rotates the object according to the waves so that it's points are not under water
        if (transform.position.y < waveHeight)
        {
            Vector3 checkVelocity = rb.angularVelocity;
            if (checkVelocity.x > prevVelocity.x + 1)
            {
                rb.angularVelocity = new Vector3(prevVelocity.x + 1, rb.angularVelocity.y, rb.angularVelocity.z);
            }
            prevVelocity = rb.angularVelocity;
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y)/ depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}

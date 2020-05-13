using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity += new Vector3(fireSpeed, 2, 0);
    }
}

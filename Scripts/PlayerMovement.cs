using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float speed = .1f;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + dir * speed);
    }
}
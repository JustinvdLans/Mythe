using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    float speed = .1f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + dir * speed);
    }
}
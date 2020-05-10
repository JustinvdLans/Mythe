using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float speed = .1f;

    float stamina = 5f;
    float maxStamina = 5f;

    bool isWalking = true;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + dir * speed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("I am running");
            isWalking = false;
        } else
        {
            Debug.Log("I am Not running");
            isWalking = true;
        }

        if (!isWalking)
        {
            speed = 0.2f;
            stamina -= 1f * Time.deltaTime;
        } else
        {
            speed = 0.1f;
            stamina += 0.5f * Time.deltaTime;
        }

        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }


        if(stamina <= 0)
        {
            isWalking = true;
        }
    }
}
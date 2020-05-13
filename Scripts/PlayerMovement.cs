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

    bool isRunning = false;
    bool isWalking = false;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(dir * speed);


        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            isWalking = true;
        } else
        {
            isWalking = false;
        }
       
        if(isWalking)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isWalking)
            {
                Debug.Log("I am running");
                isRunning = true;
                anim.SetBool("isWalking", false);
            } else
            {
                isRunning = false;
            }

        }
        else
        {
            Debug.Log("I am Not running");
            isRunning = false;
        }

        if (isRunning)
        {
            speed = 0.2f;
            stamina -= 1f * Time.deltaTime;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);

            if (speed >= 0.2)
            {
                speed -= 0.05f * Time.deltaTime;
                if (speed <= 0.1)
                {
                    speed = 0.1f;
                }

            } else
            {
                speed = 0.1f;
            }

            stamina += 0.5f * Time.deltaTime;
        }

        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        if(stamina <= 0)
        {
            isRunning = false;
        }

    }
}
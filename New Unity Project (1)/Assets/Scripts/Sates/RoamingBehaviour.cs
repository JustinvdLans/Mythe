using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingBehaviour : StateHandeler
{
    private Vector3 currentDirection;
    private Vector3 previousDirection;
    private float randomNumber;
    private float timer;
    private float maxTime = 5f;
    private float maxSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == States.ROAMINGSTATE)
        {
            transform.Translate(transform.forward * maxSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                ChangeDirection();
                transform.Rotate(new Vector3(0, randomNumber, 0));
                timer = 0f;
            }
        }
    }

    private void ChangeDirection()
    {
        randomNumber = Random.Range(0, 180);
    //    currentDirection = new Vector3(0, randomNumber, 0);
    }

    private void GetCurrentDirection()
    { 
        
    }
}

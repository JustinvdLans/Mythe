using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingBehaviour : StateHandeler
{

    private float health = 100f;
    private float defeatedHealth = 0f;
    private bool destroyed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 20f;
        }

        if (health <= defeatedHealth)
        {
            currentState = States.SINKINGSTATE;
            destroyed = true;
            Debug.Log("Sank ship");
        }
    }
}

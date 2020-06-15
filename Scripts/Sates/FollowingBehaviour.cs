using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehaviour : StateHandeler
{
    private float distanceToPlayer;
    private Transform playerSide;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform target;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= 50 && distanceToPlayer > 20)
        {
            currentState = States.FOLLOWINGSTATE;
            transform.LookAt(target);
            transform.position = Vector3.Lerp(transform.position, target.position, 0.001f);
            direction = (transform.position - target.transform.position).normalized;
        }

        else if (distanceToPlayer <= 20)
        {
            Debug.Log("Man all cannons!");
            currentState = States.ATTACKSTATE;
        }

        else if (distanceToPlayer >= 50)
        {
            currentState = States.ROAMINGSTATE;
        }

    }
}

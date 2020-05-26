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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= 60)
        {
            currentState = States.FOLLOWINGSTATE;
            transform.position = Vector3.Lerp(transform.position, target.position, 0.01f);
            direction = (this.transform.position - target.transform.position).normalized;
            Debug.Log(direction);
        }

        else if (distanceToPlayer >= 60)
        {
            currentState = States.ROAMINGSTATE;
        }
    }
}

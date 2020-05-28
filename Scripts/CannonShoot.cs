using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] Transform ballPos;
    [SerializeField] Rigidbody Ball;
    float forceAmount = 5000; 
    [SerializeField] GameObject effect; //Shoot particle

    void Update()
    {
        ShootCannon();
    }

    void ShootCannon()
    {
        Rigidbody ballRigid;
        if (Input.GetButtonDown("Fire1"))
        {
            ballRigid = Instantiate(Ball, ballPos.position, ballPos.rotation) as Rigidbody;
            ballRigid.AddForce(ballPos.forward * forceAmount);
            Instantiate(effect, ballPos.position, ballPos.rotation);
        }
    }
}
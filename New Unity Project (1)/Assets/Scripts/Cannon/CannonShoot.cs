using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] Transform ballPos;
    [SerializeField] Rigidbody Ball;
    float forceAmount = 2000;
    [SerializeField] private GameObject effect; //Shoot particle
    private float timer;
    private float maxTimer = 1.5f;
    [SerializeField]
    private AudioSource cannonFire;

    void Update()
    {
        timer += Time.deltaTime;
        ShootCannon();
    }

    void ShootCannon()
    {
        Rigidbody ballRigid;
        if (timer >= maxTimer)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                cannonFire.Play();
                ballRigid = Instantiate(Ball, ballPos.position, ballPos.rotation) as Rigidbody;
                ballRigid.AddForce(ballPos.forward * forceAmount);
                Instantiate(effect, ballPos.position, ballPos.rotation);
                timer = 0;
            }
        }
    }
}

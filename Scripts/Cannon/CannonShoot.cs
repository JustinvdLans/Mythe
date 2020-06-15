using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] Transform ballPos;
  //  [SerializeField] Rigidbody ballRb;
    float speed = 20f;
    [SerializeField]
    private GameObject ball;
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

    public void ShootCannon()
    {
        
        if (timer >= maxTimer)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject projectile = Instantiate(ball, ballPos.position, ballPos.rotation);
                projectile.transform.position = ballPos.position;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = ballPos.transform.forward * speed;
                cannonFire.Play();
                Instantiate(effect, ballPos.position, ballPos.rotation);
                timer = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonFire : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Transform enemyBallPos;
    private float speed = 20f;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private AudioSource cannonFire;
    private float timer;
    private float maxTimer = 1.5f;

    private void Update()
    {
        timer += Time.deltaTime;
        EnemyFire();
    }

    public void EnemyFire()
    {
        if (timer >= maxTimer)
        {
            GameObject projectile = Instantiate(ball, enemyBallPos.position, enemyBallPos.rotation);
            projectile.transform.position = enemyBallPos.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = enemyBallPos.forward * speed;
           // cannonFire.Play();
            Instantiate(effect, enemyBallPos.position, enemyBallPos.rotation);
            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateHandeler
{
    private float damage;
    [SerializeField]
    private float range;
    private int hitPercentage;
    private bool lineOfSight;
    private bool nextToTarget = false;
    [SerializeField]
    private float timer = 3f;
    private bool activateTimer = false;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float maxSpeed;
    private float distance;
    [SerializeField]
    private GameObject leftCannons;
    [SerializeField]
    private GameObject rightCannons;

    // Update is called once per frame
    void Update()
    {
        if (activateTimer)
        {
            timer -= Time.deltaTime;
        }

        distance = Vector3.Distance(transform.position, player.transform.position);
        AttackCheck();
        CheckSide();
        //    GetComponentInChildren<EnemyCannonFire>().EnemyFire();
        if (nextToTarget)
        {
            StayNextToPlayer();
        }
    }

    private void CheckSide()
    {
        RaycastHit hit;
        RaycastHit rightHit;
        bool didHit = false;

        Debug.Log(didHit);

        if (Physics.Raycast(transform.position, -transform.right, out hit, range) && distance <= 20)
        {
            Debug.Log(hit.collider);
            nextToTarget = true;
            didHit = true;
        }

        if (Physics.Raycast(transform.position, transform.right, out rightHit, range) && distance <= 20)
        {
            Debug.Log(rightHit.collider);
            nextToTarget = true;
            didHit = true;
        }

        else if(!didHit)
        {
            nextToTarget = false;
        }
    }

    private void StayNextToPlayer()
    {
        transform.rotation = player.transform.rotation;
        transform.position += transform.forward * maxSpeed * Time.deltaTime;
    }

    private void AttackCheck()
    {
        if (nextToTarget)
        {
            Debug.Log("I'm next to the tartget");
            HitCheck();
        }
        Debug.Log("I'm not next to the tartget");
    }

    private void Attack()
    {
        leftCannons.GetComponentInChildren<EnemyCannonFire>().EnemyFire();
        rightCannons.GetComponentInChildren<EnemyCannonFire>().EnemyFire();
        Debug.Log("attacking");
    }

    private void HitCheck()
    {
        if (nextToTarget)
        {
            hitPercentage = Random.Range(0, 100);
            activateTimer = true;
            Debug.Log(hitPercentage);

            if (hitPercentage > 0 && hitPercentage <= 45 && timer <= 0)
            {
                activateTimer = false;
                Debug.Log("You got hit noob");
                Attack();
                timer = 2f;
            }
        }
    }
}

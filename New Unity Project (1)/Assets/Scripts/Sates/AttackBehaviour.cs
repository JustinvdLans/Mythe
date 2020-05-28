using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateHandeler
{
    private float damage;
    private float range;
    private int hitPercentage;
    private bool lineOfSight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitCheck();
      //  Debug.Log(hitPercentage);
    }

    private void AttackCheck()
    { 
    
    }

    private void Attack()
    {
        if (hitPercentage > 0 && hitPercentage <= 45)
        {
            Debug.Log("You got hit noob");
        }
    }

    private void HitCheck()
    {
        hitPercentage = Random.Range(0, 100);
    }
}

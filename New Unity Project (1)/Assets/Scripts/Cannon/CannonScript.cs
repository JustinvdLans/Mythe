using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private GameObject cannonball;
    private float timer = 1.5f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (timer <= 0)
            {
                Instantiate(cannonball, firePos.position, Quaternion.identity);
                timer = 1.5f;
            }
        }
    }
}

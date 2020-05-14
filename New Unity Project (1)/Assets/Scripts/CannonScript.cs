using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private GameObject cannonball;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(cannonball, firePos.position, Quaternion.identity);
        }
    }
}

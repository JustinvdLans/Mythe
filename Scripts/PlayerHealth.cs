using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Security.Cryptography;

public class PlayerHealth : MonoBehaviour
{

    public Text ratioText;
    private float health = 100;
    public Image CurrentHealth;
    float damage;
    private float maxHealth = 100;
    float imageHeight = 0.1f;

    [SerializeField]
    Color lowHealthColor;

    [SerializeField]
    Color mediumHealthColor;

    private void Start()
    {
        UpdateHealth();
    }


    private void UpdateHealth()
    {
        float ratio = health / maxHealth;
        CurrentHealth.rectTransform.localScale = new Vector3(ratio,imageHeight,1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
        
    }

    private void TakeDamage(float damage)
    {

        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead Whale");
        }

        if (health <= 50)
        {
            CurrentHealth.color = mediumHealthColor;

            if (health <= 20)
            {
                CurrentHealth.color = lowHealthColor;
            }
        }

        UpdateHealth();
    }

    private void Update()
    {
        if (Input.GetKey("h"))
        {
            TakeDamage(0.1f);
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
       
    }

}

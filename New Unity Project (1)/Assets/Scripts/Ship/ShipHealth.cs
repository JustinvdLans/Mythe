using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipHealth : MonoBehaviour
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

    //Updates The healthbar and the percentage
    private void UpdateHealth()
    {
        float ratio = health / maxHealth;
        CurrentHealth.rectTransform.localScale = new Vector3(ratio, imageHeight, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';

    }

    //Makes you take damage
    private void TakeDamage(float damage)
    {
        //damage
        health -= damage;

        //Check if player is dead, doesnt do anything yet
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead Whale");
        }
        //Changes healthbar color by certain amount of health
        if (health <= 50)
        {
            CurrentHealth.color = mediumHealthColor;

            if (health <= 20)
            {
                CurrentHealth.color = lowHealthColor;
            }
        }
        //Updates the healthbar after damage is taken
        UpdateHealth();
    }

    private void Update()
    {
        //Just a quick way to test the healthbar
        if (Input.GetKey("h"))
        {
            TakeDamage(0.1f);
        }

        //Fixes you cant get more than max health
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float health = 100f;
    //public float Health { get { return health; } set { health = value; } }
    private float currentHealth;
    //public float CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    private Image enemyBar;
    //public Image EnemyBar { get { return enemyBar; } set { enemyBar = value; } }
    //public float Damage { get { return damage; } set { damage = value; } }
    [SerializeField]
    private GameObject enemyUI;
    //public GameObject EnemyUI { get { return enemyUI; } set { enemyUI = value; } }
    [SerializeField]
    private AudioSource explosion;
    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        enemyUI = GameObject.FindGameObjectWithTag("UI");
        enemyBar = enemyUI.GetComponent<Image>();
        currentHealth = health;
    }

    public void WhenDamage(float damage)
    {
        explosion.Play();
        currentHealth -= damage;
        enemyBar.fillAmount = currentHealth / health;
        if (currentHealth <= 0)
        {
            anim.SetBool("isSinking", false);
            Destroy(gameObject, 1);
        }
    }
}

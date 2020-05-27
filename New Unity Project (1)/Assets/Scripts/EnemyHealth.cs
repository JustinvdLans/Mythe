using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float health = 100f;
    private float currentHealth;
    private Image enemyBar;
    public float damage = 10f;
    public Image EnemyBar { get { return enemyBar; } set { enemyBar = value; } }
    [SerializeField]
    private GameObject enemyUI;

    // Start is called before the first frame update
    void Start()
    {
        enemyBar = enemyUI.GetComponent<Image>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        enemyBar.fillAmount = currentHealth / health;
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentHealth -= damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private AudioSource combatMusic;
    [SerializeField]
    private AudioSource mainMusic;
    private bool functionActivated = false;

    // Start is called before the first frame update
    private void Start()
    {
        enemyUI = GameObject.FindGameObjectWithTag("UI");
        enemyBar = enemyUI.GetComponent<Image>();
        currentHealth = health;
    }

    private void Update()
    {
        if (!functionActivated)
        {
            if (currentHealth < health && currentHealth > 0)
            {
                Debug.Log("Check");
                combatMusic.Play();
                functionActivated = true;
            }
        }
    }

    public void WhenDamage(float damage)
    {
        mainMusic.Pause();
        explosion.Play();
        currentHealth -= damage;
        enemyBar.fillAmount = currentHealth / health;
        if (currentHealth <= 0)
        {
            combatMusic.Stop();
            mainMusic.UnPause();
            anim.SetBool("isSinking", true);
            Destroy(gameObject, 1.6f);
            SceneManager.LoadScene("VictoryScreen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
}

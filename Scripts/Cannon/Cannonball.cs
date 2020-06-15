using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
	[SerializeField]
	private GameObject effect;

	// Use this for initialization
	void Start()
	{
		Destroy(gameObject, 3);
	}

	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			collision.gameObject.GetComponent<EnemyHealth>().WhenDamage(1f);
		}

		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<ShipHealth>().TakeDamage(0.5f);
		}

		if (!collision.gameObject.CompareTag("Cannonball"))
		{
			Destroy(gameObject);
			Instantiate(effect, transform.position, transform.rotation);
		}
	}
}

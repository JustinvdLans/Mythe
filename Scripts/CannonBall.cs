using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		StartCoroutine("Destroyer");
	}

	// Update is called once per frame
	void OnCollisionEnter()
	{
		Destroy(gameObject);
	}
	IEnumerator Destroyer()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}

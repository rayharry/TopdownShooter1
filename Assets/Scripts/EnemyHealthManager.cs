using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	// If we need to reference the current health, we'll use the private int, not the global.
	public int health;
	private int currentHealth;

	// Use this for initialization
	void Start () {

		// When we start the game, the enemy's current health will be set to the health.
		currentHealth = health;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	// The "hurt enemy" will have a certain number, according to the damage value.

	public void HurtEnemy(int damage)
	{
		// It takes the damage value from the currentHealth.

		currentHealth -= damage;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// It's important to add the namespace of Unity UI, otherwise we couldn't reference that.
// Otherwise you could reference the whole thing with dot Unityengine dot whatever.

public class PlayerHealthManager : MonoBehaviour {

	public int startingHealth;
	private int currentHealth;

	// Code for the time when player flashes to white.
	public float flashLength;
	private float flashCounter;

	private Renderer flashy;
	private Color storedColor;

	// Reference to the unity ui slider, named healthbar
	public Slider healthbar;

	// Use this for initialization
	void Start () {

		// Setting the current health to starting health, start of frame. 
		currentHealth = startingHealth;

		// Actually setting our custom renderer to be something.
		flashy = GetComponent<Renderer>();

		// Setting the first color, accessing the material's normal color.
		storedColor = flashy.material.GetColor("_Color");

	}
	
	// Update is called once per frame
	void Update () {

		// Setting the value actively to the player's health.
		healthbar.value = currentHealth;

		if (currentHealth <= 0)
		{
			// This will deactivate the object which has this script attached to it.
			gameObject.SetActive(false);
		}

		if (flashCounter > 0)
		{
			// Counting down with the deltatime
			flashCounter -= Time.deltaTime;

			// If the flashcounter goes equal or zero
			if (flashCounter <= 0)
			{
				// Returning the color, which we stored in the Start function
				flashy.material.SetColor("_Color", storedColor);
			}
		}
	}


	public void HurtPlayer(int damageAmount)
	{
		currentHealth -= damageAmount;

		// Setting the color to be white during the hurting.
		flashCounter = flashLength;
		flashy.material.SetColor("_Color", Color.white);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour {

	private PlayerController thePlayerDude;
	public Teleporter teleportier;

	// Use this for initialization
	void Start () {

	}

	/*
	public void OnTriggerEnter(Collider other)
	{
		// Search for the Player tag of the object.
		if (other.gameObject.tag == "Player")
		{
			thePlayerDude.transform.position = new Vector3(teleportier.transform.position.x + 4, teleportier.transform.position.y, teleportier.transform.position.z);
		}
	} */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private PlayerController thePlayerDude;
	public Teleporter2 teleportier2;

	// Use this for initialization
	void Start () {

	}

	/*
	public void OnTriggerEnter(Collider other)
	{
		// Search for the Player tag of the object.
		if (other.gameObject.tag == "Player")
		{
			thePlayerDude.transform.position = new Vector3(teleportier2.transform.position.x + 4, teleportier2.transform.position.y, teleportier2.transform.position.z);
		} 
	} */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	// can be used for multiple hazards, like spikes, environment, enemies, etc.
	public int damageToGive;


	public void OnTriggerEnter(Collider other)
	{
		// Search for the Player tag of the object.
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
		}
	}
}

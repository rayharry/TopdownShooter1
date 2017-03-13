using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Rigidbody myRB;
	public float moveSpeed;

	public PlayerController thePlayer;

	public Slider healthbar;

	public Teleporter teleportier;
	public Teleporter2 teleportier2;

	public bool randomStart;

	// Use this for initialization
	void Start () {

		// Setting the movement speed to random.
		moveSpeed = Random.Range(5f, 10f);

		// Search for the actual Rigidbody in the gameworld.
		myRB = GetComponent<Rigidbody>();

		// Search for an object in the gameworld, which has the Playercontroller attached to it. 
		thePlayer = FindObjectOfType<PlayerController>();

		// Randomly puts the zombies in new positions at the start of frame, if the tag is on.
		if (randomStart)
		{
			transform.position = new Vector3(Random.Range(-40f, 40f), 1f, Random.Range(-20f, 30f));
		}
	}


	void FixedUpdate() {

		//"transform forward" uses the current direction straight away. 

		//if (healthbar.value != 0)
		//{
			myRB.velocity = (transform.forward * moveSpeed);
		//}
	
	}

	// Update is called once per frame
	void Update () {

		// Every object in the gameworld has the Transform column of info. From there we look at the position.
		// If you have more 3D, flying enemies etc you would also use the rotation to actually look at the player. 
		// Zombie doesn't look at player now, if his life is lower or equal to zero.

		if (healthbar.value >= 1 && thePlayer.transform.position.y < myRB.transform.position.y + 0.5 && thePlayer.transform.position.y > myRB.transform.position.y - 0.1 )
		{
			transform.LookAt(thePlayer.transform.position);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		// Collider event for the teleport one
		if (other.gameObject.tag == "Teleport")
		{
			transform.position = new Vector3(teleportier2.transform.position.x - 6, teleportier2.transform.position.y - 3, teleportier2.transform.position.z);
		}

		// Collider event for the teleport two
		if (other.gameObject.tag == "Teleport2")
		{
			transform.position = new Vector3(teleportier.transform.position.x + 3, teleportier.transform.position.y - 3, teleportier.transform.position.z);
		}
	}
}

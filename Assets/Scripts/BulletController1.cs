using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController1 : MonoBehaviour {

	public float speed;

	public float lifeTime;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame - Transform dot translate makes it move
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);


		// Makes the lifetime count DOWN with the deltatime, hence the minus
		lifeTime -= Time.deltaTime;

		if(lifeTime <= 0)
		{
			// If the lifetime is lower or equal to zero, we destroy it. 
			//This automatically refers to the object which it is attached to.

			Destroy(gameObject);
		}
	}


	// When collision occurs between this object, the bullet, and some other. 
	void OnCollisionEnter(Collision other)
	{
		// We check that the object we've collided with has the "enemy" tag in it. 

		if(other.gameObject.tag == "Enemy")
		{
			// Search the enemy health manager component, then use the hurt enemy script with set damage.
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "Obstacle")
		{
			// Bullet hits the wall and is destroyed.
			Destroy(gameObject);
		}
	}

}

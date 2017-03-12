using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


	public bool isFiring;

	// If we'll have different guns, we want to control the 
	//different speeds and styles for the bullets to come out. 

	public BulletController1 bullet;
	public float bulletSpeed;


	public float timeBetweenShots;
	private float shotCounter;


	public Transform firePoint;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame. Minus equals means we're counting down the whole time.
	// Instantiate is the function that clones the objects, telling what object, where and rotation.

	void Update () {
		if(isFiring)
		{
			shotCounter -= Time.deltaTime;
			if(shotCounter <= 0)
			{
				shotCounter = timeBetweenShots;
				BulletController1 newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController1;
				newBullet.speed = bulletSpeed; 
			}
		} else {
			shotCounter = 0;
		}
	}
}

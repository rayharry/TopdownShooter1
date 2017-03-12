using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


	public float leftLimit;
	public float rightLimit;

	public GunController theGun;

	// Setting the camerashake, both on and off, and value
	public float shake;
	public float shakeAmount;
	public float decreaseFactor;

	//private Camera mainCamera;

	// Use this for initialization
	void Start()
	{
		//mainCamera = FindObjectOfType<Camera>();

		shakeAmount = 5;
	}

	// Update is called once per frame
	void Update()
	{
		//Old version: transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);

		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		}
	}

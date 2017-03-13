using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	// voids are like functions, you can make your own but Start and Update are standard. "Start of frame", "Always" basically.


	public float moveSpeed;
	private Rigidbody myRigidbody;

	// Private means a number only for this script.

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;
	public float shake;
	public float shakeAmount;
	public float decreaseFactor;
	public bool cameraShake;

	public GunController theGun;

	public bool useController;
	public bool running;
	public float jumpCooldown;
	public float jumpThrust;

	public Teleporter teleportier;
	public Teleporter2 teleportier2;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();
	}


	// Get raw makes it stop really fast, without a slope
	// Update is called once per frame
	void Update () {

		// Quit game function
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		// Setting the position for the camera with and without the screenshake.
		if(cameraShake) {
			mainCamera.transform.position = new Vector3((transform.position.x - shakeAmount) + Random.Range(0, shakeAmount * 2),transform.position.y +  15,((transform.position.z - shakeAmount) + Random.Range(0, shakeAmount * 2))-4);
			//shake -= Time.deltaTime * decreaseFactor;
		}

		if(!cameraShake) {
			mainCamera.transform.position = new Vector3(transform.position.x,transform.position.y + 15,transform.position.z - 4);
		}


		// Moving around with the traditional keys

		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

		// Setting running controls
		if(running) {
			moveVelocity = moveInput * moveSpeed * 1.5f;
		}

		if(!running) {
			moveVelocity = moveInput * moveSpeed;
		}


		// Ray is a beam coming out of a point. The plane is a mathematical plane, not a physical object in the gameworld.
		// Rotating with the mouse below.

		if(!useController)
			{
			Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
			Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
			float rayLength;

			if (groundPlane.Raycast(cameraRay, out rayLength))
			{
				Vector3 pointToLook = cameraRay.GetPoint(rayLength);
				//Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

				transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
			}

			// Mouse button 0 is left, 1 is right, 2 is middle. 
			if(Input.GetAxis("Fire1") > 0)  
				theGun.isFiring = true;
			              
			if(Input.GetAxis("Fire1") <= 0)  
				theGun.isFiring = false;

			// Running controls
			if (Input.GetAxis("Run") > 0)
			{
				running = true;
			}

			if (Input.GetAxis("Run") <= 0)
			{
				running = false;
			}

			// Jumping controls
			if (Input.GetAxis("Jump") > 0 && jumpCooldown <= 0 && Input.GetAxis("Jetpack") <= 0)
			{
				transform.position = new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z);
				jumpThrust += 1f;
				jumpCooldown += 0.8f;
			}

			if (jumpThrust > 0)
			{
				transform.position = new Vector3(transform.position.x,transform.position.y + 0.4f,transform.position.z);
				jumpThrust -= Time.deltaTime * 7;
			}

			if (jumpCooldown > 0)
			{
				jumpCooldown -= Time.deltaTime;
			}

			// Jumping controls
			if (Input.GetAxis("Jetpack") > 0)
			{
				transform.position = new Vector3(transform.position.x,transform.position.y + 0.3f,transform.position.z);
			}
		}


		// Includes the Shake amount set for camera.
		if(theGun.isFiring)
		{
			cameraShake = true;
		}

		if(!theGun.isFiring)
		{
			cameraShake = false;
		}


		// Rotate with a controller.
		if(useController)
		{
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");

			if(playerDirection.sqrMagnitude > 0.0f)
			{
				transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
			}

			if(Input.GetKeyDown(KeyCode.Joystick1Button5))
			{
				theGun.isFiring = true;
			}

			if(Input.GetKeyUp(KeyCode.Joystick1Button5))
			{
				theGun.isFiring = false;
			}
		}

	}



	public void OnTriggerEnter(Collider other)
	{
		// Collider event for the teleport one
		if (other.gameObject.tag == "Teleport" && transform.position.x < teleportier.transform.position.x)
		{
			transform.position = new Vector3(teleportier2.transform.position.x - 6, teleportier2.transform.position.y-1, teleportier2.transform.position.z);
		}

		// Collider event for the teleport two
		if (other.gameObject.tag == "Teleport2" && transform.position.x < teleportier2.transform.position.x)
		{
			transform.position = new Vector3(teleportier.transform.position.x + 3, teleportier.transform.position.y -1, teleportier.transform.position.z);
		}

		if (other.gameObject.tag == "Teleport" && transform.position.x > teleportier.transform.position.x)
		{
			transform.position = new Vector3(teleportier2.transform.position.x - 3, teleportier2.transform.position.y-1, teleportier2.transform.position.z);
		}

		// Collider event for the teleport two
		if (other.gameObject.tag == "Teleport2" && transform.position.x > teleportier2.transform.position.x)
		{
			transform.position = new Vector3(teleportier.transform.position.x + 6, teleportier.transform.position.y -1, teleportier.transform.position.z);
		}
	}

	public void OnTriggerStay(Collider other)
	{
		// When player hits the gravlift, it transports player into the air. CURRENTLY NOT USED.
		if (other.gameObject.tag == "Gravlift")
		{
			transform.position = new Vector3(transform.position.x,transform.position.y + 0.1f,transform.position.z);
		}
	}

	void FixedUpdate() {
		// Speed of the body
		myRigidbody.velocity = moveVelocity;

	}
}

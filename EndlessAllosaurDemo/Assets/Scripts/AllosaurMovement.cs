using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllosaurMovement : MonoBehaviour {

	private CharacterController myController;
	private float speed = 5.0f;
	private Vector3 myVector;
	private float gravity = 12.0f;
	private float gVel;
	private float animationDuration = 2.0f;
	private float startTime = 0.0f;

	private bool isDead = false;


	// Use this for initialization
	void Start () {

		myController = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		myVector = Vector3.zero;

		if (isDead)
			return;

		if (Time.time - startTime < animationDuration) {

			myController.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		if (myController.isGrounded) {

			gVel = -0.5f;
		} else {

			gVel -= gravity * Time.deltaTime;
		}

		myVector.x = Input.GetAxisRaw ("Horizontal") * speed;

		if (Input.GetMouseButton(0)) {

			if (Input.mousePosition.x > Screen.width / 2) {

				myVector.x = speed;
			} else {

				myVector.x = -speed;
			}
		}
		myVector.y = gVel;
		myVector.z = speed;
		myController.Move (myVector * Time.deltaTime);
	}

	public void SpeedSetter(float mod){

		speed = 5.0f + mod;
	}
		// this function will be called everytime our player hits another collider
	private void OnControllerColliderHit(ControllerColliderHit colInfo){

		if (colInfo.collider.tag == "Obstacle") {

			Death ();
		}
	}

	void Death(){

		isDead = true;
		GetComponent<ScoreManager> ().OnDeath ();
	}
}

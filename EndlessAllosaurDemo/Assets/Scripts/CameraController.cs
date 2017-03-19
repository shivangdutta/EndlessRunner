using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform playerPostion;
	private Vector3 startingPosOffset;
	private Vector3 myVector;
	private float animationDuration = 2.0f;
	private float transition = 0.0f;
	private Vector3 cameraStartPos = new Vector3 (0.11f, 13f, -19.63f);

	// Use this for initialization
	void Start () {

		playerPostion = GameObject.FindGameObjectWithTag ("Player").transform;
		startingPosOffset = transform.position - playerPostion.position;
	}
	
	// Update is called once per frame
	void Update () {

		myVector = playerPostion.position + startingPosOffset;

		myVector.x = 0;
		myVector.y = Mathf.Clamp (myVector.y, 5, 9);

		if (transition > 1.0f) {

			transform.position = myVector;
		} else {

			transform.position = Vector3.Lerp (myVector + cameraStartPos , myVector, transition);
			transition += Time.deltaTime * 1 / animationDuration;
			transform.LookAt (playerPostion.position + Vector3.up);
		}
	}
}

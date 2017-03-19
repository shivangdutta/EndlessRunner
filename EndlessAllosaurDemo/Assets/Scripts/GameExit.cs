using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void QuitGame(){

		if (Application.isPlaying) {

			Application.Quit ();
		}
	}
}

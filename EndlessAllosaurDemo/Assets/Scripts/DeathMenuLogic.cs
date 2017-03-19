using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuLogic : MonoBehaviour {

	public Image bgImg;
	public Text textScore;

	private bool isShown = false;
	private float transition = 0.0f;

	// Use this for initialization
	void Start () {

		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (!isShown) {

			return;
		}

		transition += Time.deltaTime;
		bgImg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void ToggleLastMenu(float score){

		gameObject.SetActive (true);
		textScore.text = ((int)score).ToString ();
		isShown = true;
	}

	public void PlayAgain(){

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);	//this will load the active scene again
	}

	public void MenuChange(){

		SceneManager.LoadScene("Menu");
	}
}

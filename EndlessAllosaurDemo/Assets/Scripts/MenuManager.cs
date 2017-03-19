using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text myHighScoreText;
	// Use this for initialization
	void Start () {

		myHighScoreText.text = "HighScore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString();
	}

	public void LoadGame(){

		SceneManager.LoadScene ("Gameplay");
	}
}

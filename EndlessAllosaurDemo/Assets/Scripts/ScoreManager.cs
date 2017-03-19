using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private float score = 0.0f;

	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int nextLevelIn = 10;

	private bool isDead = false;

	public Text scoreText;
	public DeathMenuLogic myObject;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (isDead)
			return;
		
		if (score >= nextLevelIn) {

			LevelUp ();
		}


		score += Time.deltaTime * 1.2f;
		scoreText.text = ((int)score).ToString ();
	}

	void LevelUp(){

		if (difficultyLevel == 20) {

			return;
		}

		nextLevelIn *= 2;
		difficultyLevel++;

		GetComponent<AllosaurMovement> ().SpeedSetter (difficultyLevel);
	}

	public void OnDeath(){

		isDead = true;
		if (PlayerPrefs.GetFloat ("Highscore") < score) {

			PlayerPrefs.SetFloat ("Highscore", score);
		}
		myObject.ToggleLastMenu (score);
	}
}

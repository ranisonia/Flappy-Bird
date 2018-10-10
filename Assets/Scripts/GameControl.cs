using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Globalization;

public class GameControl : MonoBehaviour {
	//Using Singelton pattern to make only one instance of the Game Controller Class
	//By making it static we can call it from another method
	public static GameControl instance;
	//Refrensing gameovertext
	public  GameObject gameOverText;
	//Tracking the gameover is happen
	public bool gameOver = false;
	//Scrolling speed of sprite
	public float scrollSpeed=-1.5f;
	//By default score
	private int score=0;
	//Score Text Variable
	public Text scoreText;

	public Text highScore;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameOverText);
		}
	}
	// Update is called once per frame
	void Update () {
		//Restart the Game by tapping
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			//
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
	void Start(){
		highScore.text = PlayerPrefs.GetInt ("highScore").ToString();
	}
	//method to check if the bird  scored or not 
	public void BirdScored(){
		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "Score:" + score.ToString ();
		PlayerPrefs.SetInt ("score",score);
		if (PlayerPrefs.HasKey ("highScore")) {
			if (score>PlayerPrefs.GetInt("highScore")) {
				PlayerPrefs.SetInt ("highScore",score);
			}
		} else {
			PlayerPrefs.SetInt ("highScore",score);
		}
	}

	public void BirdDied(){
		//show the gameover text
		gameOverText.SetActive (true);
		gameOver = true;
	}
}

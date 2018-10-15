using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
	public void StartGame(){
		Debug.Log ("Loading Main Scene");
		SceneManager.LoadScene ("Main Scene",LoadSceneMode.Single);
	}

	public void Settings(){
		Debug.Log ("Settings Clicked!");
	}

	public void Store(){
		Debug.Log ("Store Clicked!");
	}
}

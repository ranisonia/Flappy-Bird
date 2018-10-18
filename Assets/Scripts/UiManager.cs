using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public GameObject Start;
    public GameObject Settings;
    public GameObject Store;
	public void StartGame(){
		Debug.Log ("Loading Main Scene");
		SceneManager.LoadScene ("Main Scene",LoadSceneMode.Single);
	}

	public void Settings_Menu(){
        Start.SetActive(false);
        Settings.SetActive(true);
		Debug.Log ("Settings Clicked!");
	}

    public void Store_Menu() {
        Start.SetActive(false);
        Store.SetActive(true);
    }

    public void BackPressed() {
        Start.SetActive(true);
        Settings.SetActive(false);
        Store.SetActive(false);
        Debug.Log("Back Button Pressed");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
	//This script is for the scrolling of the game background
	//Scrolling speed can be managed from the GameControl script


	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		//get the rigid body component
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//accessing the velocity of the rigid body and adding a new scenery
			rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
		}
		if (GameControl.instance.gameOver == true) {
			rb2d.velocity = Vector2.zero;
		}
	}
}

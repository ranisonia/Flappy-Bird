using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingScript : MonoBehaviour {
	//Create a box collider to repead the ground scene
	private BoxCollider2D groundCollider;
	//Accessing the ground length
	private float groundHorizontalLength;
	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		//Checking the position of bird and creating a scenery again
		if (transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
	}
	//Method will reposition the background
	private void RepositionBackground(){
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
		transform.position = (Vector2) transform.position + groundOffset;
	}
}

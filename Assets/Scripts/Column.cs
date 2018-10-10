using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
	//Checking if the bird passes the collider
	private void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Bird> () != null) {
			//Calling the Bird Scored method to increment and show the results
			GameControl.instance.BirdScored ();
		}
	}
}

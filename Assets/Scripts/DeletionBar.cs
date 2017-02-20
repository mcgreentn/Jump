using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletionBar : MonoBehaviour {

	//Public variable to store a reference to the player game object
	public GameObject player;

	//Private variable to store the offset distance between the player and camera
    public float offsetY;

	// LateUpdate is called after Update each frame
	void LateUpdate ()
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		float newY = player.transform.position.y + offsetY;
		if(newY > transform.position.y) {
			transform.position = new Vector3(0f, player.transform.position.y + offsetY, 0f);
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		// Destroy the ghost object
		if(other.gameObject.tag.Equals("Player")) {
			RestartScript.Restart1();
		} else {
			Destroy(other.gameObject);
		}
	}
}

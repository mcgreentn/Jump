using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object


    private float offsetY;         //Private variable to store the offset distance between the player and camera


    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(0f, player.transform.position.y + offsetY, -20f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRow : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")) {
            GameManager.Score += 1;

            // it only triggers once
            this.GetComponent<Collider2D>().enabled = false;

            Destroy(this.gameObject);
        }
    }
}

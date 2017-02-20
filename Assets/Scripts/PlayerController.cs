using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float upMult;
	public float sideMult;
	private Rigidbody2D rb;
	public Animator anim;

	public bool animTriggered;
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		animTriggered = false;
	}

	void Update() {
		if(Input.GetKeyDown ("left")) {
			// kill velocity in x direction
			// float oldVelY = rb.velocity.y / 5;
			//rb.velocity = new Vector2 (0f, 0f);

			//rb.AddForce(Vector2.left * speed * sideMult * Time.deltaTime);
			//rb.AddForce(Vector2.up * speed * upMult * Time.deltaTime);
			rb.velocity = new Vector2 (-speed * sideMult, speed * upMult);
		}
		else if(Input.GetKeyDown ("right")) {
			// kill velocity in x direction
			// float oldVelY = rb.velocity.y / 5;
			// rb.velocity = new Vector2 (0f, 0f);

			// rb.AddForce(Vector2.right * speed * sideMult * Time.deltaTime);
			// rb.AddForce(Vector2.up * speed * upMult * Time.deltaTime);
			rb.velocity = new Vector2 (speed * sideMult, speed * upMult);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Wall") {
			// restart the game
			if(!animTriggered) {
				animTriggered = true;
				anim.Play("FadeOut");
				GameManager.Lost = 1;
			}
		}
	}


}

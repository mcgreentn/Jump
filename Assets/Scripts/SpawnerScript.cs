using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerScript : MonoBehaviour {

	public GameObject Row;
	public GameObject RegularBorder;
	public GameObject TriggerBorder;

	public GameObject Player;
	private Random rand;

	private int isSpawned;

	private int counter;

	public Material[] materials;
	public static int Lost;

	// Use this for initialization
	void Start () {
		this.GetComponent<Collider2D>().enabled = true;

		Player = GameObject.FindWithTag("Player");
		rand = new Random();
		Lost = 0;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Player")) {
			References.Count += 1;
			// it only triggers once
			this.GetComponent<Collider2D>().enabled = false;
			StartCoroutine(SpawnRow());
			StartCoroutine(SpawnBorders());
			// destroy this after
			Destroy(gameObject);
		}
	}


	private IEnumerator SpawnRow() {
		for(int i = 0; i < 5; i++) {
			GameObject current = Instantiate(Row) as GameObject;
			float offsetX = Random.Range(-2, 2);
			Vector3 newpos = new Vector3(0 + offsetX, Player.transform.position.y + 11 + 5*i, 0);

			current.transform.position = newpos;
			foreach (Transform child in current.transform) {
				child.gameObject.GetComponent<Renderer>().sharedMaterial= materials[(References.Count)%materials.Length];
			}
		}
		yield return new WaitForSeconds(0.0f);
	}
	private IEnumerator SpawnBorders() {
		for(int i = 0; i < 2; i++) {
			GameObject current = Instantiate(RegularBorder) as GameObject;
			Vector3 newpos = new Vector3(3.4f, Player.transform.position.y + 12 + i*13, 0);

			current.transform.position = newpos;
			foreach (Transform child in current.transform) {
				child.gameObject.GetComponent<Renderer>().sharedMaterial= materials[(References.Count)%materials.Length];
			}
			if(i < 1) {
				current = Instantiate(RegularBorder) as GameObject;
			} else {
				current = Instantiate(TriggerBorder) as GameObject;
			}
			newpos = new Vector3(-3.4f, Player.transform.position.y + 12 + i*13, 0);

			current.transform.position = newpos;

			foreach (Transform child in current.transform) {
				child.gameObject.GetComponent<Renderer>().sharedMaterial= materials[(References.Count)%materials.Length];
			}
		}


		yield return new WaitForSeconds(1.0f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour{

	public void Restart() {
		GameManager.Lost = 0;
		References.Count = 0;
		GameManager.Score = 0;
		SceneManager.LoadScene("Game");
	}

	public static void Restart1() {
		GameManager.Lost = 0;
		References.Count = 0;
		GameManager.Score = 0;
		SceneManager.LoadScene("Game");
	}
}

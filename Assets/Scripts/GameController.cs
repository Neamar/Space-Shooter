using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOVer;
	private bool restart;

	void Start() {
		gameOVer = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine(SpawnWaves ());
		score = 0;
		UpdateScore ();
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);

		while(true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOVer) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	void Update() {
		if(restart && Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOverText.text = "Game Over";
		gameOVer = true;
	}
}

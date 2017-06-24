﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;

	public int scoreValue;

	void Start() {
		GameObject gameControllerOBject = GameObject.FindWithTag ("GameController");
		if (gameControllerOBject != null) {
			gameController = gameControllerOBject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find GameController script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public float speed;

	void Start () {
		rb.velocity = new Vector3(0, 0, 1) * speed;
	}

}

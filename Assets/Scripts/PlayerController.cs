using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 v = new Vector3 (moveHorizontal, 0, moveVertical);

		Rigidbody  rb = GetComponent<Rigidbody> ();
		rb.velocity = v * speed;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (Mathf.Min(0, rb.velocity.z * -tilt * 0.5f), 0, rb.velocity.x * -tilt);
	}
}

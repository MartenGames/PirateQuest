using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;

	void Start () {
		
	}

	void FixedUpdate () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Rigidbody2D>().AddForce(-Vector2.up * speed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
		}
	}
}

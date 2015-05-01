using UnityEngine;
using System.Collections;

public class DamageHandlerScript : MonoBehaviour {

	public int health = 1;

	public float invulnerabilityTimer = 0;

	int layer;

	/*
	void OnCollisionEnter2D() {
		Debug.Log ("Collision!");
	}
	*/

	void Start() {
		layer = gameObject.layer;
	}

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger!");

		health--;
		invulnerabilityTimer = 2f;
		gameObject.layer = 11;
	}

	void Update() {
		invulnerabilityTimer -= Time.deltaTime;

		if (invulnerabilityTimer <= 0) {
			gameObject.layer = layer;
		}

		if (health <= 0) {
			Die ();
		}
	}

	void Die() {
		Destroy (gameObject);
	}
}

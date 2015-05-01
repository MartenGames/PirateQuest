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

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Trigger!");
		Debug.Log (other.gameObject.name);

		if(other.gameObject.name == "Bullet(Clone)") {
			health--;
			invulnerabilityTimer = 2f;
			gameObject.layer = 11;
		}
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

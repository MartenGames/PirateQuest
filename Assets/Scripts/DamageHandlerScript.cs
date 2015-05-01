using UnityEngine;
using System.Collections;

public class DamageHandlerScript : MonoBehaviour {

	public int health = 1;

	/*
	void OnCollisionEnter2D() {
		Debug.Log ("Collision!");
	}
	*/

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger!");
		health--;

		if (health <= 0) {
			Die ();
		}
	}

	void Die() {
		Destroy (gameObject);
	}
}

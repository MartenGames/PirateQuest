using UnityEngine;
using System.Collections;
using System.Globalization;

public class DamageHandlerScript : MonoBehaviour {

	public int health = 1;

	public float invulnerabilityTimer = 0;

	public AudioClip sinkShip;

	int layer;

	public GameObject Gold;
	public float xCoordinate;
	public float yCoordinate;

	//Use this to compare strings
	private CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo; 

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
			//invulnerabilityTimer = 2f;
			//gameObject.layer = 11;
		}
		if (other.gameObject.name == "EnemyBullet(Clone)") {
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
		//Spawn gold when enemy ship is destroyed.

		if (myComp.IsPrefix(gameObject.name, "Enemy" )) {

			//Get the position of the sinking ship.
			xCoordinate = gameObject.transform.position.x;
			yCoordinate = gameObject.transform.position.y;

			Destroy (gameObject);
			AudioSource.PlayClipAtPoint(sinkShip, transform.position);
			Instantiate (Gold, new Vector3 (xCoordinate, yCoordinate, 0), transform.rotation);
		} else {
			Destroy (gameObject);
		}
	}
}

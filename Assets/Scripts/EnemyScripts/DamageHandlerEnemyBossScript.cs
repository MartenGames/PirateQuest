using UnityEngine;
using System.Collections;

public class DamageHandlerEnemyBossScript : MonoBehaviour {

	public int health = 100;
	public AudioClip sinkShip;
	public GameObject Gold;
	public float xCoordinate;
	public float yCoordinate;

	void Start() {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Bullet(Clone)") {
			health--;
		}
	}

	void Update() {
		if (health <= 0) {
			Die ();
		}
	}

	void Die() {
		//Spawn gold when enemy ship is destroyed.
		//Get the position of the sinking ship.
		xCoordinate = gameObject.transform.position.x;
		yCoordinate = gameObject.transform.position.y;
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(sinkShip, transform.position);
		Instantiate (Gold, new Vector3 (xCoordinate, yCoordinate, 0), transform.rotation);
	}
}

using UnityEngine;
using System.Collections;

public class DamageHandlerEnemyScript : MonoBehaviour {

	public int health;
	public int damage;
	public AudioClip sinkShip;
	public GameObject Gold;
	public float xCoordinate;
	public float yCoordinate;
	float blinkTime;
	Material material;
	Color color;

	void Start() {
		damage = GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript> ().damage;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
		blinkTime = 0f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Bullet(Clone)" || other.gameObject.name == "SecondBullet(Clone)") {
			health -= damage;
			blinkTime = 0.25f;
		}
	}

	void Update() {
		if (health <= 0) {
			Die ();
		}

		blinkTime -= Time.deltaTime;

		if (0 < blinkTime && blinkTime <= 0.25) {
			material.color = Color.red;
		} else {
			material.color = color;
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

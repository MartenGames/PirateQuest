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
			material.color = Color.red;
		}
	}

	void Update() {
		if (health <= 0) {
			Die ();
		}

		blinkTime -= Time.deltaTime;

		if (blinkTime <= 0f) {
			material.color = color;
		} else {
			material.color = Color.red;
		}
	}

	void Die() {
		//Spawn gold when enemy ship is destroyed.
		//Get the position of the sinking ship.
		xCoordinate = gameObject.transform.position.x;
		yCoordinate = gameObject.transform.position.y;
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(sinkShip, transform.position);
		GameObject go = (GameObject)Instantiate (Gold, new Vector3 (xCoordinate, yCoordinate, 0), transform.rotation);
		Debug.Log ("NAME: " + gameObject.tag);
		if (gameObject.tag == "Enemy1") {
			Debug.Log ("enemy1");
		} else if (gameObject.tag == "Enemy2") {
			Debug.Log ("enemy2");
		} else if (gameObject.tag == "Enemy3") {
			Debug.Log ("enemy3");
		} else {
			Debug.Log ("enemy??");
		}

		go.GetComponent<GoldScript> ().goldAmount = 100;
	}
}

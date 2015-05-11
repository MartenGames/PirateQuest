using UnityEngine;
using System.Collections;

public class DamageHandlerEnemyScript : MonoBehaviour {

	public int damage;
	public AudioClip sinkShip;
	public GameObject Gold;
	public float xCoordinate;
	public float yCoordinate;
	float blinkTime;
	Material material;
	Color color;
	EnemyHealthScript enemyHealth;

	void Start() {
		damage = GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript> ().damage;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
		blinkTime = 0f;
		enemyHealth = gameObject.GetComponent<EnemyHealthScript> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Bullet(Clone)" || other.gameObject.name == "SecondBullet(Clone)" ||
		   other.gameObject.name == "FireBullet(Clone)" || other.gameObject.name == "EnergyBall(Clone)") {
			enemyHealth.TakeDamage(damage);
			blinkTime = 0.25f;
			material.color = Color.red;
		}
	}

	void Update() {
		enemyHealth.healthSlider.value = enemyHealth.currentHealth;

		if (enemyHealth.healthSlider.value <= 0) {
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
		// Spawn gold when enemy ship is destroyed.
		// Get the position of the sinking ship.
		xCoordinate = gameObject.transform.position.x;
		yCoordinate = gameObject.transform.position.y;
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(sinkShip, transform.position);
		GameObject go = (GameObject)Instantiate (Gold, new Vector3 (xCoordinate, yCoordinate, 0), transform.rotation);

		if (gameObject.tag == "Enemy1") {
			go.GetComponent<GoldScript> ().goldAmount = 100;
		} else if (gameObject.tag == "Enemy2") {
			go.GetComponent<GoldScript> ().goldAmount = 200;
		} else if (gameObject.tag == "Enemy3") {
			go.GetComponent<GoldScript> ().goldAmount = 300;
		} else {
			Debug.Log ("This should never happen, check DamageHandlerEnemyScript");
			go.GetComponent<GoldScript> ().goldAmount = 100;
		}
	}
}

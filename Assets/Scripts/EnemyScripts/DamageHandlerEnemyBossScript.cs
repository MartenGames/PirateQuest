using UnityEngine;
using System.Collections;

public class DamageHandlerEnemyBossScript : MonoBehaviour {
	
	public int damage;
	public AudioClip sinkShip;
	public GameObject Gold;
	public float xCoordinate;
	public float yCoordinate;
	float blinkTime;
	Material material;
	Color color;
	EnemyBossHealthScript enemyHealth;


	void Start() {
		damage = GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript> ().damage;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
		blinkTime = 0f;
		enemyHealth = gameObject.GetComponent<EnemyBossHealthScript> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "PlayerBullet") {
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
		//Spawn gold when enemy ship is destroyed.
		//Get the position of the sinking ship.
		xCoordinate = gameObject.transform.position.x;
		yCoordinate = gameObject.transform.position.y;
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(sinkShip, transform.position);
		Instantiate (Gold, new Vector3 (xCoordinate, yCoordinate, 0), transform.rotation);
	}
}

using UnityEngine;
using System.Collections;

public class SecondBulletScript : MonoBehaviour {

	public GameObject explosionGO;
	float speed = 5;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "EnemyBullet") {
			GameObject ex = (GameObject) Instantiate(explosionGO);
			ex.transform.position = transform.position;
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (-(speed * Time.deltaTime), 0, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}

using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

	public GameObject explosionGO;
	float speed = 5;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D() {
		GameObject ex = (GameObject) Instantiate(explosionGO);
		ex.transform.position = transform.position;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		//Different from the player bullet. This bullet goes along the Y-axis.
		Vector3 velocity = new Vector3 (0, speed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}

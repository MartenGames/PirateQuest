using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float speed = 5;


	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D() {
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (speed * Time.deltaTime, 0, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}

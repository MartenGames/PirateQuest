using UnityEngine;
using System.Collections;

public class BarrelMobilityScript : MonoBehaviour {
	
	public float moveSpeed;
		
	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "BackgroundOcean" || other.gameObject.tag == "Island") {
			moveSpeed *= -1;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Island") {
			moveSpeed *= -1;
		}		                                 
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, moveSpeed * Time.deltaTime, 0));
	}
}

using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;

	Transform Player;
	
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Player == null) {
			GameObject go = GameObject.Find ("Player(Clone)");

			if(go != null) {
				Player = go.transform;
			}
		}	

		if (Player == null) {
			return;
		}

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, MoveSpeed * Time.deltaTime, 0);

		float distance = Vector3.Distance (Player.position, transform.position);


		//The enemy ship stops if it gets within a certain distance from the player.
		if (distance > 4) {
			pos += transform.rotation * velocity;
			transform.position = pos;
		}

		//RaycastHit hit;
		var fwd = transform.TransformDirection (Vector3.forward);
		fwd.Normalize ();
		//Debug.Log (hit.rigidbody.gameObject.name);
		if (Physics.Raycast (transform.position, fwd, 10)) {
			Debug.Log ("Raycast!!");
		}
	}

	void OnTriggerEnter2D() {
		Debug.Log ("flottt");
	}

	void OnCollisionEnter2D(Collision2D co) {
		//Debug.Log ("Collision!");
		//Debug.Log (co.gameObject.name);
		//Debug.Log (co.gameObject.tag);

		if (co.gameObject.tag == "Island" && co.rigidbody) {
			Debug.Log ("Collide with a island!!");
			//co.rigidbody.AddForce(Vector3.left * 1000);
			//transform.rotation = Quaternion.LookRotation(Vector3.left);
			//transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
			//transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		}
	}
}

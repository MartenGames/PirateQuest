using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;
	public RaycastHit hit;

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

		/*
		var direction = new Vector3(0, 45, 0);
		var length = 10;
		var diagonal = transform.TransformDirection(direction);
		diagonal.Normalize();
		Debug.DrawRay(transform.position, diagonal * length, Color.green);
		//Debug.Log (Physics.Raycast (transform.position, diagonal, length));
		if (Physics.Raycast(transform.position, diagonal, length)) {
			Debug.Log ("There is something in front of the object!");
		}
		*/

		var length = 10;
		var direction = new Vector3(0, 45, 0);
		var diagonal = transform.TransformDirection(direction);
		diagonal.Normalize();
		Debug.DrawRay(transform.position, diagonal * length, Color.green);
		if (Physics.Raycast (transform.position, diagonal, out hit, 10)) {
			Debug.Log ("Raycast!!");
		}

		/*
		Ray ray;
		RaycastHit hit;
		ray.origin = transform.position;
		ray.direction = Vector3.forward;
		Debug.DrawRay(ray, Color.red);
		if(Physics.Raycast(ray, out hit)) {
			Debug.Log ("Raycast hit!!");
		}
		*/
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

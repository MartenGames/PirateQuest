using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;
	public float rotateSpeed;
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

		// Face the player
		Vector3 dir = Player.position - transform.position;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotateSpeed * Time.deltaTime);

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, MoveSpeed * Time.deltaTime, 0);
		float distance = Vector3.Distance (Player.position, transform.position);

		// The enemy ship stops if it gets within a certain distance from the player.
		if (distance > 4) {
			pos += transform.rotation * velocity;
			transform.position = pos;
		}

		GameObject[] islands = GameObject.FindGameObjectsWithTag ("Island");

		foreach (GameObject island in islands) {
			Debug.Log (island.name);


			/*
			var dist = Vector3.Distance(this.transform.position, island.transform.position);
			if(dist < 6) {
				Debug.Log (dist);
				dist = 6;
				transform.position = (transform.position - island.transform.position).normalized * dist + island.transform.position;
				//Vector3 rot = new Vector3(0, 0.5f, 0);
				//transform.Rotate(Vector3.right * Time.deltaTime * 8);
				//Vector3 somePos = island.transform.position;
				//transform.RotateAround (somePos, Vector3.up, 20 * Time.deltaTime);
			}
			*/
		}
	}
}

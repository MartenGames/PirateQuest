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
		Vector3 playerVector = Player.position - transform.position;
		playerVector.Normalize ();
		float zAngle = Mathf.Atan2 (playerVector.y, playerVector.x) * Mathf.Rad2Deg - 90;
		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotateSpeed * Time.deltaTime);

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, MoveSpeed * Time.deltaTime, 0);
		float distance = Vector3.Distance (Player.position, transform.position);
		bool tmp = true;

		GameObject[] islands = GameObject.FindGameObjectsWithTag ("Island");

		foreach (GameObject island in islands) {
			Vector3 islandVector = island.transform.position - transform.position;
			Vector3 b;
			Vector3 desiredVector;
			float radius = island.GetComponent<CircleCollider2D>().radius;
			float e = 8;
			// maybe this is not in the center of the island!!
			float d = Vector3.Distance(island.transform.position, transform.position);
			float x = 0;

			Debug.Log ("Island name: "+ island.name);
			Debug.Log ("Island position: " + island.transform.position.x + " " + island.transform.position.y);
			Debug.Log ("Radius: " + radius);
			Debug.Log ("d: " + d);
			Debug.Log ("e: " + e);

			if(d < e) {
				x = ((d - radius) / (e - radius));
				b = new Vector3(-islandVector.y, islandVector.x, islandVector.z);
				desiredVector = x * playerVector + (1 - x) * b;
				desiredVector.Normalize();

				tmp = false;

				if (distance > 4) {
					pos += desiredVector * MoveSpeed * Time.deltaTime;
					transform.position = pos;
				}
			}
		}

		if (tmp) {
			if (distance > 4) {
				pos += transform.rotation * velocity;
				transform.position = pos;
			}
		}
	}
}

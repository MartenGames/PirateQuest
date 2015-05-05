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

			if (go != null) {
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

		Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
		Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
		RaycastHit2D[] hit = Physics2D.RaycastAll (myPos, playerPos - myPos, 5);
		Debug.DrawLine(pos, (playerPos - myPos) * 5, Color.green);
		
		foreach (RaycastHit2D obj in hit) {
			if(obj.collider.tag == "Island") {
				Debug.DrawLine(pos, (playerPos - myPos) * 5, Color.red);
				GameObject[] islands = GameObject.FindGameObjectsWithTag ("Island");
				
				foreach (GameObject island in islands) {
					Vector3 islandVector = island.transform.position - transform.position;
					Vector3 b;
					Vector3 desiredVector;
					float radius = island.GetComponent<CircleCollider2D>().radius;
					float e = 8;
					// Maybe this is not in the center of the island!!
					// Have to check it out!!
					float d = Vector3.Distance(island.transform.position, transform.position);
					float x = 0;
					
					if(d < e) {
						x = ((d - radius) / (e - radius));

						/*
						float angle1 = Vector3.Angle (islandVector, playerVector);
						float angle3 = Mathf.Acos(Vector3.Dot(islandVector.normalized, playerVector.normalized));
						Debug.Log ("Angle1: " + angle1);
						Debug.Log ("Angle3: " + angle3);
						Debug.Log ("Angle4: " + Mathf.Asin(angle1));
						Debug.Log ("Angle5: " + Mathf.Sin(angle1));
						float signedAngle = Mathf.Sin (Vector3.Angle (islandVector, playerVector));
						if(signedAngle < 0.0) {
							b = new Vector3(islandVector.y, -islandVector.x, islandVector.z);
						}
						else {
							b = new Vector3(-islandVector.y, islandVector.x, islandVector.z);
						}
						*/

						/*
						float angle1 = Vector3.Angle (islandVector, playerVector);
						Debug.Log ("Angle: " + angle1);

						if(0 <= angle1 && angle1 <= 15) {
							b = new Vector3(islandVector.y, -islandVector.x, islandVector.z);
						}
						else {
							b = new Vector3(-islandVector.y, islandVector.x, islandVector.z);
						}
						*/

						b = new Vector3(islandVector.y, -islandVector.x, islandVector.z);

						desiredVector = x * playerVector + (1 - x) * b;
						desiredVector.Normalize();
						
						tmp = false;
						
						if (distance > 4) {
							pos += desiredVector * MoveSpeed * Time.deltaTime;
							transform.position = pos;
						}
					}
				}
			}
		}

		if (tmp) {
			if (distance > 4) {
				pos += transform.rotation * velocity;
				transform.position = pos;
			}
		}


		/*
		GameObject[] islands = GameObject.FindGameObjectsWithTag ("Island");

		foreach (GameObject island in islands) {
			Vector3 islandVector = island.transform.position - transform.position;
			Vector3 b;
			Vector3 desiredVector;
			float radius = island.GetComponent<CircleCollider2D>().radius;
			float e = 8;
			// Maybe this is not in the center of the island!!
			// Have to check it out!!
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
		*/
	}
}

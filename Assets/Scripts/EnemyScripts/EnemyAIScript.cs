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
		//Debug.DrawLine(pos, (playerPos - myPos) * 5, Color.green);
		// Debug
		Debug.DrawLine (transform.position, transform.position + playerVector, Color.red);
		// end of debug
		
		foreach (RaycastHit2D obj in hit) {
			if(obj.collider.tag == "Island") {
				//Debug.DrawLine(pos, (playerPos - myPos) * 5, Color.red);
				GameObject[] islands = GameObject.FindGameObjectsWithTag ("Island");

				//float sdfas = obj.collider.transform.position.x;

				
				foreach (GameObject island in islands) {
					// TEST
					/*
					float testx = island.GetComponent<CircleCollider2D>().transform.position.x;
					float testy = island.GetComponent<CircleCollider2D>().transform.position.y;
					float offsetx = island.GetComponent<CircleCollider2D>().offset.x;
					float offsety = island.GetComponent<CircleCollider2D>().offset.y;
					float lol = testx + offsetx;
					float lol2 = testy + offsety;
					Debug.Log ("Name: " + island.name);
					Debug.Log("Circle x: " + lol);
					Debug.Log("Circle y: " + lol2);
					*/
					// END OF TEST
					float centerIslandX = island.GetComponent<CircleCollider2D>().transform.position.x;
					float centerIslandY = island.GetComponent<CircleCollider2D>().transform.position.y;
					// Vector3 islandPos = new Vector3(centerIslandX, centerIslandY, transform.position.z);
					Vector3 islandPos = new Vector3(centerIslandX, centerIslandY, transform.position.z);
					Vector3 islandVector = islandPos - transform.position;
					islandVector.Normalize();
					// Debug
					Debug.DrawLine (transform.position, transform.position + islandVector * 50, Color.blue);
					// end of debug
					//Vector3 islandVector = island.transform.position - transform.position;
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

						// TEST
						float z = playerVector.x * islandVector.y - islandVector.x * playerVector.y;
						Debug.Log ("z: " + z);
						// END OF TEST

						if(z < 0.1) {
							b = new Vector3(-islandVector.y, islandVector.x, islandVector.z);
						}
						else {
							b = new Vector3(islandVector.y,-islandVector.x, islandVector.z);

						}

						b.Normalize();
						// Debug
						Debug.DrawLine (transform.position, transform.position + b, Color.cyan);
						// end of debug

						// b = new Vector3(islandVector.y, -islandVector.x, islandVector.z);

						desiredVector = x * playerVector + (1 - x) * b;
						desiredVector.Normalize();

						// Debug
						Debug.DrawLine (transform.position, transform.position + desiredVector, Color.black);
						// end of debug

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

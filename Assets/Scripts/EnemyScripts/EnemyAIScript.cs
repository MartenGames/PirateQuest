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
	}

	void OnTriggerEnter2D() {
		Debug.Log ("flottt");
	}

	void OnCollistionEnter2D() {
		Debug.Log ("Flott2324");
	}
}

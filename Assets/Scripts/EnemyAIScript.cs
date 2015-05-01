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

		GameObject go = GameObject.Find ("Player");

		Player = go.transform;

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, MoveSpeed * Time.deltaTime, 0);

		float distance = Vector3.Distance (Player.position, transform.position);


		//The enemy ship stops if it gets within a certain distance from the player.
		if (distance > 4) {
			pos += transform.rotation * velocity;
			transform.position = pos;
		}

	}

}

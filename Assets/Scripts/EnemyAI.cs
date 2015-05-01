using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;
	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float XDif;
	private float YDif;

	// Update is called once per frame
	void Update () {

		//Assign the Player Vector to the position of the player
		Player = GameObject.Find("Player").transform.position;

		//Find the difference in coordinates between the enemy and the player
		XDif = Player.x - transform.position.x;
		YDif = Player.y - transform.position.y;

		//Create a new vector with the coordinates
		PlayerDirection = new Vector2 (XDif, YDif);

		//Only move the enemy if he is at a certain distance from the player
		if(Vector2.Distance(Player, transform.position) > Distance) {
			transform.position += (Vector3)PlayerDirection.normalized * MoveSpeed * Time.deltaTime;
		}
	}
}

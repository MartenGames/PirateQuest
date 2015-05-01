using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;

	private Vector3 Player;

	private Vector2 PlayerDirection;

	private float XDif;
	private float YDif;
	
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//Assign the Player Vector to the position of the player
		Player = GameObject.Find("Player").transform.position;

		//A formula to rotate the enemy ships towards the player
		Vector3 dir = Player - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

		//Find the difference in coordinates between the enemy and the player
		XDif = Player.x - transform.position.x;
		YDif = Player.y - transform.position.y;

		//Create new vectors with the recently calculated coordinates
		PlayerDirection = new Vector2 (XDif, YDif);

		//Only move the enemy if he is at a certain distance from the player
			transform.position += (Vector3)PlayerDirection.normalized * MoveSpeed * Time.deltaTime;

	}

	//Boolean that says if the enemy shop can move
	bool CanMove () {
		return (Vector2.Distance (Player, transform.position) > Distance); 
	}
	


}

using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float MoveSpeed;
	public float Distance;

	private Vector3 Player;
	private Vector3 Enemy;

	private Vector2 PlayerDirection;
	private Vector2 EnemyDirection;

	private float XDif;
	private float YDif;
	private float EnemyXDif;
	private float EnemyYDif;




	void Start () {

	}

	// Update is called once per frame
	void Update () {



		//Assign the Player Vector to the position of the player
		Player = GameObject.Find("Player").transform.position;


		if ((Enemy = GameObject.Find ("Enemy").transform.position) == null) {
			continue;
		}


		//A formula to rotate the enemy ships towards the player
		Vector3 dir = Player - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

		//Find the difference in coordinates between the enemy and the player
		XDif = Player.x - transform.position.x;
		YDif = Player.y - transform.position.y;

		//Find the distance between current enemy and another enemy
		EnemyXDif = Enemy.x - transform.position.x;
		EnemyYDif = Enemy.y - transform.position.y;

		//Create new vectors with the recently calculated coordinates
		PlayerDirection = new Vector2 (XDif, YDif);
		EnemyDirection = new Vector2 (EnemyXDif, EnemyYDif);


		//If a enemy is nearby then move from him
		if (Vector2.Distance (Enemy, transform.position) < Distance) {
			transform.position = (transform.position - Enemy).normalized * MoveSpeed + Enemy;

		}

		//Only move the enemy if he is at a certain distance from the player
		if(CanMove()) {
			transform.position += (Vector3)PlayerDirection.normalized * MoveSpeed * Time.deltaTime;
		}
	}

	//Boolean that says if the enemy shop can move
	bool CanMove () {
		return (Vector2.Distance (Player, transform.position) > Distance); 
	}
	


}

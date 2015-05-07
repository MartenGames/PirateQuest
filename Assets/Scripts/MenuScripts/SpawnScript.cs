using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coordinate {
	public float x;
	public float y;
	
	public Coordinate() {
		x = 0;
		y = 0;
	}
}

public class SpawnScript : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject EnemyBoss;
	public int numberOfEnemies;
	public int numberOfEnemies2;
	public int numberOfEnemies3;
	public bool SpawnBoss;
	public GameObject[] spawnPoints;
	List<Coordinate> coords = new List<Coordinate> ();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numberOfEnemies; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints[i].transform.position.x;
			co.y =  spawnPoints[i].transform.position.y;
			coords.Add(co);
		}

		SpawnPlayer ();
		SpawnEnemy ();
		if (numberOfEnemies2 != 0) {
			SpawnEnemy2 ();
		}
		if (numberOfEnemies3 != 0) {
			SpawnEnemy3 ();
		}
		if (EnemyBoss) {
			SpawnEnemyBoss();
		}
	}

	void SpawnPlayer() {
		Instantiate (player, new Vector3 (0, 0, 0), transform.rotation);
		//GameObject spawnPlayer = (GameObject)Instantiate (player, new Vector3 (0, 0, 0), transform.rotation);
		//Debug.Log (spawnPlayer.GetComponent<DamageHandlerPlayerScript>().defeatCanvas);
	}

	void SpawnEnemy () {
		for(int i = 0; i < numberOfEnemies; i++) {
			Debug.Log (transform.rotation);
			Instantiate (enemy, new Vector3 (coords[i].x, coords[i].y, 0), transform.rotation);

		}
	}

	void SpawnEnemy2 () {
		for(int i = 0; i < numberOfEnemies2; i++) {
			Instantiate (enemy2, new Vector3 (coords[i].x, coords[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemy3 () {
		for(int i = 0; i < numberOfEnemies3; i++) {
			Instantiate (enemy3, new Vector3 (coords[i].x, coords[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemyBoss () {
		Instantiate (EnemyBoss, new Vector3 (spawnPoints[1].transform.position.x, spawnPoints[1].transform.position.y, 0)	, transform.rotation);
	}
}

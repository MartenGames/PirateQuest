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
	public GameObject enemy;
	public int numberOfEnemies = 2;
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

		SpawnEnemy ();
	}

	void SpawnEnemy () {
		for(int i = 0; i < numberOfEnemies; i++) {
			Instantiate (enemy, new Vector3 (coords[i].x, coords[i].y, 0), transform.rotation);
		}
	}

}

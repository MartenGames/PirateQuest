using UnityEngine;
using System.Collections;

public class Level7Script : MonoBehaviour {


	public GameObject[] enemies; //Enemy to be spawned
	public GameObject[] spawnPoints; //Spawn location of enemies

	int numberOfEnemies; //number of enemies to be spawned

	bool spawned; //

	int numEnemy;

	public int secondsBetweenEnemies;

	int counter;

	GameObject go;

	// Use this for initialization
	void Awake () {

		go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().AllowedToWin = false;
		spawned = false;
		counter = 1;
		numEnemy = 0;
		numberOfEnemies = spawnPoints.Length * enemies.Length;
	}

	IEnumerator spawnEnemies() {

		spawned = true;

		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate (enemies[numEnemy], new Vector3 (spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, 0), transform.rotation);
			yield return new WaitForSeconds (secondsBetweenEnemies);
			counter++;
		}

		numEnemy++;

		spawned = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!spawned && counter <= numberOfEnemies) {
			StartCoroutine("spawnEnemies");
		}

		if (counter == numberOfEnemies) {
			go.GetComponent<StoringVarScript> ().AllowedToWin = true;
		}

	}       
}

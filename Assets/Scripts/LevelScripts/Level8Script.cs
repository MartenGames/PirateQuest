using UnityEngine;
using System.Collections;

public class Level8Script : MonoBehaviour {
	
	
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;

	public GameObject[] spawnPoints_enemy1;
	public GameObject[] spawnPoints_enemy2;
	public GameObject[] spawnPoints_enemy3;
	public GameObject[] spawnPoints_enemy4;
	public GameObject[] spawnPoints_enemy5;
	
	public int numberOfEnemies1;
	public int numberOfEnemies2;
	public int numberOfEnemies3;
	public int numberOfEnemies4;
	public int numberOfEnemies5;
	public int totalNumberOfEnemies;

	public int secondsBetweenEnemies;
	bool spawned;
	int counter;
	GameObject go;

	void Awake () {
		go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().AllowedToWin = false;
		spawned = false;
		counter = 1;
	}
	
	IEnumerator spawnEnemies() {
		spawned = true;

		for (int i = 0; i < numberOfEnemies1; i++) {
			Instantiate (enemy1, new Vector3 (spawnPoints_enemy1[i].transform.position.x, spawnPoints_enemy1[i].transform.position.y, 0), transform.rotation);
			counter++;
		}

		yield return new WaitForSeconds (secondsBetweenEnemies);

		for (int i = 0; i < numberOfEnemies2; i++) {
			Instantiate (enemy2, new Vector3 (spawnPoints_enemy2[i].transform.position.x, spawnPoints_enemy2[i].transform.position.y, 0), transform.rotation);
			counter++;
		}

		yield return new WaitForSeconds (secondsBetweenEnemies);

		for (int i = 0; i < numberOfEnemies3; i++) {
			Instantiate (enemy3, new Vector3 (spawnPoints_enemy3[i].transform.position.x, spawnPoints_enemy3[i].transform.position.y, 0), transform.rotation);
			counter++;
		}

		yield return new WaitForSeconds (secondsBetweenEnemies);

		for (int i = 0; i < numberOfEnemies4; i++) {
			Instantiate (enemy4, new Vector3 (spawnPoints_enemy4[i].transform.position.x, spawnPoints_enemy4[i].transform.position.y, 0), transform.rotation);
			counter++;
		}

		yield return new WaitForSeconds (secondsBetweenEnemies);

		for (int i = 0; i < numberOfEnemies5; i++) {
			Instantiate (enemy5, new Vector3 (spawnPoints_enemy5[i].transform.position.x, spawnPoints_enemy5[i].transform.position.y, 0), transform.rotation);
			counter++;
		}

		/*
		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate (enemy, new Vector3 (spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, 0), transform.rotation);
			yield return new WaitForSeconds (secondsBetweenEnemies);
			counter++;
		}*/
		
		spawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawned && counter <= totalNumberOfEnemies) {
			StartCoroutine("spawnEnemies");
		}
		
		if (counter == totalNumberOfEnemies) {
			go.GetComponent<StoringVarScript> ().AllowedToWin = true;
		}
		
	}       
}

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

	//References to enemies
	public GameObject player;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	public GameObject octopusBaby;
	public GameObject EnemyBoss;


	//Number of enemies to spawn
	public int numberOfEnemies;
	public int numberOfEnemies2;
	public int numberOfEnemies3;
	public int numberOfEnemies4;
	public int numberOfEnemies5;
	public int numberOfBabies;

	//Boolean value to decide if to spawn enemy boss
	public bool SpawnBoss;
	bool babiesSpawned;

	//Arrays to keep track of spawnpoints  of where to spawn enemeis
	public GameObject[] spawnPoints_enemy1;
	public GameObject[] spawnPoints_enemy2;
	public GameObject[] spawnPoints_enemy3;
	public GameObject[] spawnPoints_enemy4;
	public GameObject[] spawnPoints_enemy5;
	public GameObject[] spawnPoints_babies;



	//Spawnpoint for the enemy boss
	public GameObject BossSpawn;

	//Coordinates of the spawn points
	List<Coordinate> coords_enemy1 = new List<Coordinate> ();
	List<Coordinate> coords_enemy2 = new List<Coordinate> ();
	List<Coordinate> coords_enemy3 = new List<Coordinate> ();
	List<Coordinate> coords_enemy4 = new List<Coordinate> ();
	List<Coordinate> coords_enemy5 = new List<Coordinate> ();
	List<Coordinate> coords_babies = new List<Coordinate> ();

	//Players health
	int health;
	int enemyBossHealth;

	//Different sprite that varies by players health
	public Sprite firstSprite;
	public Sprite secondSprite;
	public Sprite thirdSprite;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		health = GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().health;
		spriteRenderer = player.GetComponent<SpriteRenderer> ();

		babiesSpawned = false;

		for(int i = 0; i < numberOfEnemies; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_enemy1[i].transform.position.x;
			co.y =  spawnPoints_enemy1[i].transform.position.y;
			coords_enemy1.Add(co);
		}

		for(int i = 0; i < numberOfEnemies2; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_enemy2[i].transform.position.x;
			co.y =  spawnPoints_enemy2[i].transform.position.y;
			coords_enemy2.Add(co);
		}

		for(int i = 0; i < numberOfEnemies3; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_enemy3[i].transform.position.x;
			co.y =  spawnPoints_enemy3[i].transform.position.y;
			coords_enemy3.Add(co);
		}

		for(int i = 0; i < numberOfEnemies4; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_enemy4[i].transform.position.x;
			co.y =  spawnPoints_enemy4[i].transform.position.y;
			coords_enemy4.Add(co);
		}

		for(int i = 0; i < numberOfEnemies5; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_enemy5[i].transform.position.x;
			co.y =  spawnPoints_enemy5[i].transform.position.y;
			coords_enemy5.Add(co);
		}

		for(int i = 0; i < numberOfBabies; i++) {
			Coordinate co = new Coordinate();
			co.x =  spawnPoints_babies[i].transform.position.x;
			co.y =  spawnPoints_babies[i].transform.position.y;
			coords_babies.Add(co);
		}

		SpawnPlayer ();
		SpawnEnemy ();
		if (numberOfEnemies2 != 0) {
			SpawnEnemy2 ();
		}
		if (numberOfEnemies3 != 0) {
			SpawnEnemy3 ();
		}
		if (numberOfEnemies4 != 0) {
			SpawnEnemy4 ();
		}
		if (numberOfEnemies5 != 0) {
			SpawnEnemy5 ();
		}
		if (SpawnBoss) {
			SpawnEnemyBoss();
		}

	}

	void SpawnPlayer() {
		if (health == 0) {
			spriteRenderer.sprite = firstSprite;
		} else if (health == 25) {
			spriteRenderer.sprite = secondSprite;
		} else if (health == 50) {
			spriteRenderer.sprite = thirdSprite;
		} else {
			spriteRenderer.sprite = thirdSprite;
		}
		Instantiate (player, new Vector3 (0, 0, 0), transform.rotation);
		//GameObject spawnPlayer = (GameObject)Instantiate (player, new Vector3 (0, 0, 0), transform.rotation);
		//Debug.Log (spawnPlayer.GetComponent<DamageHandlerPlayerScript>().defeatCanvas);
	}

	void SpawnEnemy () {
		for(int i = 0; i < numberOfEnemies; i++) {
			Instantiate (enemy, new Vector3 (coords_enemy1[i].x, coords_enemy1[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemy2 () {
		for(int i = 0; i < numberOfEnemies2; i++) {
			Instantiate (enemy2, new Vector3 (coords_enemy2[i].x, coords_enemy2[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemy3 () {
		for(int i = 0; i < numberOfEnemies3; i++) {
			Instantiate (enemy3, new Vector3 (coords_enemy3[i].x, coords_enemy3[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemy4 () {
		for(int i = 0; i < numberOfEnemies4; i++) {
			Instantiate (enemy4, new Vector3 (coords_enemy4[i].x, coords_enemy4[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemy5 () {
		for(int i = 0; i < numberOfEnemies5; i++) {
			Instantiate (enemy5, new Vector3 (coords_enemy5[i].x, coords_enemy5[i].y, 0), transform.rotation);
		}
	}

	void SpawnEnemyBoss () {
		Instantiate (EnemyBoss, new Vector3 (BossSpawn.transform.position.x, BossSpawn.transform.position.y, 0)	, transform.rotation);
	}

	void SpawnBabies() {

		for(int i = 0; i < numberOfBabies; i++) {
			Instantiate (octopusBaby, new Vector3 (coords_babies[i].x, coords_babies[i].y, 0), transform.rotation);
		}
		babiesSpawned = true;
	}

	void Update () {




		if (EnemyBoss != null) {
			enemyBossHealth = GameObject.Find ("EnemyBoss(Clone)").GetComponent<EnemyBossHealthScript> ().currentHealth;
			if (enemyBossHealth < 10 && enemyBossHealth >= 0 && !babiesSpawned) {
				Debug.Log ("SPAWN BABIES");
				SpawnBabies ();
			}
		}


	}
}

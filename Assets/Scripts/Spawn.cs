using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	private GameObject SpawnPoint;

	// Use this for initialization
	void Start () {

		SpawnPoint = GameObject.Find ("SpawnPoint");
		SpawnEnemy ();
	}
	
	// Update is called once per frame

	void SpawnEnemy () {


		for (int i = 0; i < 3; i++) {
			Instantiate (enemy, new Vector3 (SpawnPoint.transform.position.x,SpawnPoint.transform.position.y, 0), transform.rotation);

		}
	}
}

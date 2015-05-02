using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject SpawnPoint1;
	public GameObject SpawnPoint2;
	public int numberOfEnemies;
	private float X1, X2, Y1, Y2;

	// Use this for initialization
	void Start () {
	
		//Find the x and y coordinates of the two spawn points
		X1 = SpawnPoint1.transform.position.x;
		Y1 = SpawnPoint1.transform.position.y;
		X2 = SpawnPoint2.transform.position.x;
		Y2 = SpawnPoint2.transform.position.y;

		SpawnEnemy ();
	}
	
	// Update is called once per frame

	void SpawnEnemy () {

		Instantiate (enemy, new Vector3 (X1, Y1, 0), transform.rotation);
		Instantiate (enemy, new Vector3 (X2, Y2, 0), transform.rotation);
	}

}

using UnityEngine;
using System.Collections;

public class Level7Script : MonoBehaviour {


	public GameObject enemy;

	public GameObject spawnPoint;

	public int numberOfEnemies;

	public int secondsBetweenEnemies;
	GameObject go;

	// Use this for initialization
	void Start () {

		go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().AllowedToWin = false;
	}

	void spawnEnemies() {

		for (int i = 0; i < numberOfEnemies; i++) {
			Instantiate (enemy, new Vector3 (spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), transform.rotation);
			StartCoroutine("waitFor");
		}

		go.GetComponent<StoringVarScript> ().AllowedToWin = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator waitFor () {
		yield return new WaitForSeconds(secondsBetweenEnemies);
	}
	          
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class EnemyBossShootingScript : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 3f, 0);
	public Vector3 babyOctopusOffset = new Vector3(0, 10f, 0);
	public Vector3 bulletOffset2 = new Vector3(3f, 0, 0);
	public Vector3 bulletOffset3 = new Vector3(-3f, 0, 0);

	public GameObject bulletPrefab;
	public GameObject bulletPrefabBackward;
	public GameObject bulletPrefabRight;
	public GameObject bulletPrefabLeft;

	public GameObject octopusBaby;
		
	public AudioClip gunShot;
	public float coolDownTimer = 0;
	public float fireDelay = 0.3f;
	float spawnBabyTime;
	Transform Player;

	/*
	void shootAllDirections () {
		Vector3 offset = new Vector3(0, 3f, 0);
		Vector3 offset2 = new Vector3(0, -3f, 0);
		Vector3 offset3 = new Vector3(3f, 3f, 0);
		Vector3 offset4 = new Vector3(-3f, 3f, 0);
		Vector3 offset5 = new Vector3(-3f, -3f, 0);
		Vector3 offset6 = new Vector3(3f, -3f, 0);
		Vector3 offset7 = new Vector3(-3f, 2, 0);
		Vector3 offset8 = new Vector3(3f, 2, 0);
		Vector3 offset9 = new Vector3(-3f, 0, 0);
		Vector3 offset10 = new Vector3(3f, 0, 0);

		Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
		Instantiate (bulletPrefabBackward, transform.position + offset2, transform.rotation);
		Instantiate (bulletPrefab, transform.position + offset3, transform.rotation);
		Instantiate (bulletPrefab, transform.position + offset4, transform.rotation);
		Instantiate (bulletPrefabBackward, transform.position + offset5, transform.rotation);
		Instantiate (bulletPrefabBackward, transform.position + offset6, transform.rotation);
		Instantiate (bulletPrefabLeft, transform.position + offset7, transform.rotation);
		Instantiate (bulletPrefabRight, transform.position + offset8, transform.rotation);
		Instantiate (bulletPrefabLeft, transform.position + offset9, transform.rotation);
		Instantiate (bulletPrefabRight, transform.position + offset10, transform.rotation);
		
	}

*/

	void Start() {
		spawnBabyTime = 10f;
	}

	//Spawn octopus Baby every give time limit
	/*
	void spawnBaby () {
		Vector3 offset = transform.rotation * babyOctopusOffset;
		Instantiate (octopusBaby, transform.position + offset, transform.rotation);
		spawnBabyTime = 10f;
	}
	*/

	void Update () {

		spawnBabyTime -= Time.deltaTime;

		if (spawnBabyTime < 0) {
	//		spawnBaby();
			//shootAllDirections();
		}

		if (Player == null) {
			GameObject go = GameObject.Find ("Player(Clone)");
			
			if(go != null) {
				Player = go.transform;
			}
		}	
		
		if (Player == null) {
			return;
		}
		 
		float distance = Vector3.Distance (Player.position, transform.position);

		coolDownTimer -= Time.deltaTime;

		//Only shoot within a certain distance
		if (distance < 15) {
			if (coolDownTimer <= 0) {
				coolDownTimer = fireDelay;

				coolDownTimer = fireDelay;
				Vector3 offset = transform.rotation * bulletOffset;
				Vector3 offset2 = transform.rotation * bulletOffset2;
				Vector3 offset3 = transform.rotation * bulletOffset3;
				Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
				Instantiate (bulletPrefab, transform.position + offset + offset2, transform.rotation);
				Instantiate (bulletPrefab, transform.position + offset + offset3, transform.rotation);
				AudioSource.PlayClipAtPoint(gunShot, transform.position);

			}
		}

	}
}

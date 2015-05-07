using UnityEngine;
using System.Collections;


public class EnemyBossShootingScript : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 3f, 0);
	public Vector3 bulletOffset2 = new Vector3(3f, 0, 0);
	public GameObject bulletPrefab;
	public AudioClip gunShot;
	public float coolDownTimer = 0;
	public float fireDelay = 0.3f;
	Transform Player;

	// Update is called once per frame
	void Update () {

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
		if (distance < 10) {
			if (coolDownTimer <= 0) {
				coolDownTimer = fireDelay;

				coolDownTimer = fireDelay;
				Vector3 offset = transform.rotation * bulletOffset;
				Vector3 offset2 = transform.rotation * bulletOffset2;
				Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
				Instantiate (bulletPrefab, transform.position + offset + offset2, transform.rotation);
				AudioSource.PlayClipAtPoint(gunShot, transform.position);

			}
		}

	}
}

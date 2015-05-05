using UnityEngine;
using System.Collections;


public class EnemyBossShootingScript : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 3f, 0);
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
		if (distance < 20) {
			if (coolDownTimer <= 0) {
				coolDownTimer = fireDelay;

				Vector3 offset = transform.rotation * bulletOffset;

				GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
				AudioSource.PlayClipAtPoint(gunShot, transform.position);
				bulletGO.layer = gameObject.layer;

			}
		}

	}
}

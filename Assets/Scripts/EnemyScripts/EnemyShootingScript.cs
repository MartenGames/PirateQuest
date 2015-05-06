using UnityEngine;
using System.Collections;


public class EnemyShootingScript : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
	public GameObject bulletPrefab;
	public AudioClip gunShot;
	public float coolDownTimer = 0;
	public float fireDelay = 1f;
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

		Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
		Vector3 forwardVector = transform.TransformVector (new Vector3 (0, 1, 0));
		Vector2 forwardPos = new Vector2(forwardVector.x, forwardVector.y);
		//Vector3 forwardVector = vec;
		
		RaycastHit2D[] hit = Physics2D.RaycastAll (myPos, forwardPos, 100);
		//Debug.DrawLine (transform.position, transform.position + forwardVector * 100, Color.green);

		foreach (RaycastHit2D obj in hit) {
			if(obj.collider.tag == "Player") {
				Debug.Log ("PLAYER!!");
				//Debug.DrawLine (transform.position, transform.position + forwardVector * 100, Color.red);

				if (distance < 10) {
					if (coolDownTimer <= 0) {
						coolDownTimer = fireDelay;
						Vector3 offset = transform.rotation * bulletOffset;
						Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
						AudioSource.PlayClipAtPoint(gunShot, transform.position);
					}
				}
			}
		}
	}
}

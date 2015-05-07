	using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {


	public float fireRate = 0;
	public float damage = 10;
	public float coolDownTimer = 0;
	public float fireDelay = 1f;
	public LayerMask whatToHit;
	public GameObject bulletPrefab;

	public AudioClip cannonSound;
	
	float timeToFire = 0;
	Transform  firePoint;
	
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError("ERROR: No firePoint!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		coolDownTimer -= Time.deltaTime;
		// Debug : Shoot ();
		// Single fire weapon
		if (fireRate == 0) {
			// Just a reminder for Daniel
			// I will remove this comment later
			// Input.GetButtonDown("Fire1");
			// Check if we pushed the space button
			if(Input.GetKeyDown(KeyCode.Space) && coolDownTimer <= 0) {
				coolDownTimer = fireDelay;
				Shoot();
			}
		}
		// Not single fire weapon
		// Will maybe implement later but erase this if we do not use
		else {
			// Check if we are holding down the space button
			if(Input.GetKey(KeyCode.Space) && Time.time > timeToFire) {
				timeToFire = (Time.time +  (1 / fireRate));
				Shoot();
			}
		}
	}
	
	// Shooting function
	void Shoot() {
		Vector3 firePointPos = new Vector3 (firePoint.position.x, firePoint.position.y, 0);
		Instantiate (bulletPrefab, firePointPos, transform.rotation);
		AudioSource.PlayClipAtPoint (cannonSound, transform.position);
	}
}

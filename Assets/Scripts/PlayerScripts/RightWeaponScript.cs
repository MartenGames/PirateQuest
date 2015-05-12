using UnityEngine;
using System.Collections;

public class RightWeaponScript : MonoBehaviour {
	
	public float coolDownTimer = 0;
	public float fireDelay = 1f;
	public LayerMask whatToHit;
	public GameObject bulletPrefab;
	public GameObject fireBulletPrefab;
	public GameObject energyBulletPrefab;
	public AudioClip cannonSound;
	
	int damage;
	Transform  firePoint;
	
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError("ERROR: No firePoint!");
		}
		//If the player updated the fireRate
		fireDelay -= GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().fireRate;
		damage = GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().damage;
	}
	
	// Update is called once per frame
	void Update () {
		coolDownTimer -= Time.deltaTime;
		// Just a reminder for Daniel
		// I will remove this comment later
		// Input.GetButtonDown("Fire1");
		// Check if we pushed the space button
		if((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.K)) && coolDownTimer <= 0) {
			coolDownTimer = fireDelay;
			Shoot();
		}
	}
	
	// Shooting function
	void Shoot() {
		Vector3 firePointPos = new Vector3 (firePoint.position.x, firePoint.position.y, 0);
		if (damage == 1) {
			Instantiate (bulletPrefab, firePointPos, transform.rotation);
		} else if (damage == 2) {
			Instantiate (energyBulletPrefab, firePointPos, transform.rotation);
		} else if (damage == 3) {
			Instantiate (fireBulletPrefab, firePointPos, transform.rotation);
		} else {
			Instantiate (fireBulletPrefab, firePointPos, transform.rotation);
		}
		AudioSource.PlayClipAtPoint (cannonSound, transform.position);
	}
}

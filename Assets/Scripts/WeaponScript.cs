using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {
	
	public float fireRate = 0;
	public float damage = 10;
	public LayerMask notToHit;
	
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
		// Single fire weapon
		if (fireRate == 0) {
			// Just a reminder for Daniel
			// I will remove this comment later
			// Input.GetButtonDown("Fire1");
			// Check if we pushed the space button
			if(Input.GetKeyDown(KeyCode.Space)) {
				Shoot();
			}
		}
		// Not single fire weapon
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
		Debug.Log ("Test");
	}
}

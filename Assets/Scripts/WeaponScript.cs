using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	
	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;
	
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
		//Shoot ();
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
		//Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPos = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 endPointPos = new Vector2 (firePointPos.x + 100, firePointPos.y + 100);
		//RaycastHit2D hit = Physics2D.Raycast (firePointPos, moustPos - firePointPos, 100, notToHit);
		RaycastHit2D hit = Physics2D.Raycast (firePointPos, endPointPos - firePointPos, 100, whatToHit);
		Debug.DrawLine (firePointPos, ((endPointPos - firePointPos) * 100), Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPos, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + damage + " damage");
		}
	}
}

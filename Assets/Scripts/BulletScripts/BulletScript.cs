﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject explosionGO;
	public AudioClip explosionAudio;
	float speed = 5;
	
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "BackgroundOcean") {
			GameObject ex = (GameObject) Instantiate(explosionGO);
			ex.transform.position = transform.position;
			AudioSource.PlayClipAtPoint(explosionAudio, transform.position, 0.5f);
		}
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (speed * Time.deltaTime, 0, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}

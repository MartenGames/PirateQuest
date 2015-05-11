﻿using UnityEngine;
using System.Collections;

public class StoreAudio : MonoBehaviour {

	public AudioSource storeAudio;
	
	// Use this for initialization
	void Start () {
		storeAudio = storeAudio.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			if (storeAudio.mute) {
				storeAudio.mute = false;
			}
			else {
				storeAudio.mute = true;
			}
		}
	}
}
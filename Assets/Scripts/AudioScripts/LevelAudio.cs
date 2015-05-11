using UnityEngine;
using System.Collections;

public class LevelAudio : MonoBehaviour {

	public AudioSource seaAudio;
	public AudioSource battleAudio;

	// Use this for initialization
	void Start () {
		seaAudio = seaAudio.GetComponent<AudioSource> ();
		battleAudio = battleAudio.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			if (AudioListener.volume == 1.0f) {
				AudioListener.volume = 0.0f;
			} else {
				AudioListener.volume = 1.0f;
			}
		}
	}
}

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
			if (seaAudio.mute) {
				seaAudio.mute = false;
			}
			else if(!seaAudio.mute) {
				seaAudio.mute = true;
			}
			if (battleAudio.mute) {
				battleAudio.mute = false;
			}
			else if (!battleAudio.mute) {
				battleAudio.mute = true;
			}
		}
	}
}

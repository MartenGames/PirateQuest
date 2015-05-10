using UnityEngine;
using System.Collections;

public class FirstSceneScript : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = audio.GetComponent<AudioSource>();
	}

	public void pressContinue() {
		Application.LoadLevel ("PirateTalk");
	}

	public void pressSkip () {
		Application.LoadLevel ("LevelSelection");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			if (audio.mute) {
				audio.mute = false;
			}
			else {
				audio.mute = true;
			}
		}
	}
}

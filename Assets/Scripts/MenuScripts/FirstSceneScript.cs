using UnityEngine;
using System.Collections;

public class FirstSceneScript : MonoBehaviour {

	public AudioSource firstAudio;

	// Use this for initialization
	void Start () {
		firstAudio = firstAudio.GetComponent<AudioSource>();
	}

	public void pressContinue() {
		Application.LoadLevel ("PirateTalk");
	}

	public void pressSkip () {
		Application.LoadLevel ("LevelSelection");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			if (AudioListener.volume == 1.0f) {
				AudioListener.volume = 0.0f;
			} else {
				AudioListener.volume = 1.0f;
			}
		}
	}
}

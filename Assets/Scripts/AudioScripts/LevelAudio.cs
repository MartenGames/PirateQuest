using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelAudio : MonoBehaviour {

	public AudioSource seaAudio;
	public AudioSource battleAudio;
	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;
	GameObject go;
	
	// Use this for initialization
	void Start () {
		go = GameObject.Find ("EmptyObject(Clone)");
		seaAudio = seaAudio.GetComponent<AudioSource> ();
		battleAudio = battleAudio.GetComponent<AudioSource> ();
		muteButton = muteButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (go == null) {
			go = GameObject.Find ("EmptyObject(Clone)");
		}

		if (Input.GetKeyDown(KeyCode.M)) {
			if (AudioListener.volume == 1.0f) {
				AudioListener.volume = 0.0f;
				go.GetComponent<StoringVarScript>().audio = 0;
				muteButton.image.overrideSprite = mute;
			} else {
				AudioListener.volume = 1.0f;
				go.GetComponent<StoringVarScript>().audio = 1;
				muteButton.image.overrideSprite = unmute;
			}
		}

		if (go.GetComponent<StoringVarScript> ().audio == 0) {
			muteButton.image.overrideSprite = mute;
		} else {
			muteButton.image.overrideSprite = unmute;
		}
	}
}

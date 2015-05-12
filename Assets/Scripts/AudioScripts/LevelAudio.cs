using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelAudio : MonoBehaviour {

	public AudioSource seaAudio;
	public AudioSource battleAudio;
	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;
	
	// Use this for initialization
	void Start () {
		seaAudio = seaAudio.GetComponent<AudioSource> ();
		battleAudio = battleAudio.GetComponent<AudioSource> ();
		muteButton = muteButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			if (AudioListener.volume == 1.0f) {
				AudioListener.volume = 0.0f;
				muteButton.image.overrideSprite = mute;
			} else {
				AudioListener.volume = 1.0f;
				muteButton.image.overrideSprite = unmute;
			}
		}
	}
}

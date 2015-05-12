using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButtonScript : MonoBehaviour {

	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;

	public void ClickMute() {
		Debug.Log("here");
		if (AudioListener.volume == 1.0f) {
			AudioListener.volume = 0.0f;
			muteButton.image.overrideSprite = mute;
		} else {
			AudioListener.volume = 1.0f;
			muteButton.image.overrideSprite = unmute;
		}
	}


	// Use this for initialization
	void Start () {
		muteButton = muteButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButtonScript : MonoBehaviour {

	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;
	GameObject go;

	public void ClickMute() {

		if (AudioListener.volume == 1.0f) {
			AudioListener.volume = 0.0f;
			go.GetComponent<StoringVarScript>().audio = 0;
		} else {
			AudioListener.volume = 1.0f;
			go.GetComponent<StoringVarScript>().audio = 1;
		}
	}

	// Use this for initialization
	void Start () {
		go = GameObject.Find ("EmptyObject(Clone)");
		muteButton = muteButton.GetComponent<Button> ();
	}

	void OnGUI () {

		if (Event.current.Equals (Event.KeyboardEvent("M"))) {
			ClickMute();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (go == null) {
			go = GameObject.Find ("EmptyObject(Clone)");
		}

		if (go.GetComponent<StoringVarScript> ().audio == 0) {
			muteButton.image.overrideSprite = mute;
		} else {
			muteButton.image.overrideSprite = unmute;
		}

	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButtonScript : MonoBehaviour {

	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;
	GameObject go;

	public void ClickMute() {
		Debug.Log("here");
		if (AudioListener.volume == 1.0f) {
			AudioListener.volume = 0.0f;
			muteButton.image.overrideSprite = mute;
			go.GetComponent<StoringVarScript>().audio = 0;
		} else {
			AudioListener.volume = 1.0f;
			muteButton.image.overrideSprite = unmute;
			go.GetComponent<StoringVarScript>().audio = 1;
		}
	}


	void Awake() {

	}

	// Use this for initialization
	void Start () {
		go = GameObject.Find ("EmptyObject(Clone)");
		muteButton = muteButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey(KeyCode.M)) {
			ClickMute();
		}

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

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {

	public Button[] levels;
	public AudioSource levelMenuAudio;
	public Button muteButton;
	public Sprite mute;
	public Sprite unmute;

	void Start () {
		levelMenuAudio = levelMenuAudio.GetComponent<AudioSource> ();
		muteButton = muteButton.GetComponent<Button> ();

		GameObject emptyObject = GameObject.Find ("EmptyObject(Clone)");
		int currentLevel = emptyObject.GetComponent<StoringVarScript> ().currentLevel;

		//Grey out the levels that are not available to the player. 
		for (int i = 0; i < levels.Length; i++) {
			if((i + 1) == currentLevel) {
				levels[i].enabled = true;
			}
			else {
				levels[i].image.color = Color.gray;
				levels[i].enabled = false;
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			if (AudioListener.volume == 1.0f) {
				AudioListener.volume = 0.0f;
				muteButton.image.overrideSprite = mute;
			} else {
				AudioListener.volume = 1.0f;
				muteButton.image.overrideSprite = unmute;
			}
		}
	}

	public void LoadScene(string level)
	{
		Application.LoadLevel(level);
	}
}

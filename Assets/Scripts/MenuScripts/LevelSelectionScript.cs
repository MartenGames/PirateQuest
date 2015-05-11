using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {

	//public Button[] levels;
	public AudioSource levelMenuAudio;

	void Start () {
		levelMenuAudio = levelMenuAudio.GetComponent<AudioSource> ();
		/*
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
		}*/
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

	public void LoadScene(string level)
	{
		Application.LoadLevel(level);
	}
}

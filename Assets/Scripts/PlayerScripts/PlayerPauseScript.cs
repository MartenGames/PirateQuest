using UnityEngine;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {

		//Pause the game when playing.
		if (Input.GetKeyDown (KeyCode.P)) {
			if(Time.timeScale == 0){
				Time.timeScale = 1;
				AudioListener.volume = 1.0f;
			}
			else {
				Time.timeScale = 0;
				AudioListener.volume = 0.0f;
			}
		}
	}
}
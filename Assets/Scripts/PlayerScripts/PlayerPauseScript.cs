using UnityEngine;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {

		//Pause the game when playing.
		if (Input.GetKey (KeyCode.P)) {
			if(Time.timeScale == 0){
				Time.timeScale = 1;
			}
			else {
				Time.timeScale = 0; 
			}
		}
	}
}
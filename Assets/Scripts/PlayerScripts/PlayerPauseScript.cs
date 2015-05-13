using UnityEngine;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {

	public Canvas pauseCanvas;

	void Start () {
		pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<Canvas> ();
		pauseCanvas.gameObject.SetActive (false);
	}

	void Update () {

		//Pause the game when playing.
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause ();
		}
	}

	void Pause(){

		if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.gameObject.SetActive(false);
		}
		else {
			Time.timeScale = 0;
			pauseCanvas.gameObject.SetActive(true);
		}
	}

	public void RestartLevelFromPause(){
		//If the player wants to restart the level, the timeScale can not be 0
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);

	}

	public void GoToMapFromPause(){
		Time.timeScale = 1;
		Application.LoadLevel ("LevelSelection");
	}



}
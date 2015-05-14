using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {

	public Canvas pauseCanvas;
	public Button pauseButton;
	public Sprite pause;
	public Sprite play;

	void Start () {
		pauseCanvas = pauseCanvas.GetComponent<Canvas> ();
		pauseCanvas = GameObject.FindGameObjectWithTag ("PauseCanvas").GetComponent<Canvas> ();
		pauseCanvas.gameObject.SetActive (false);
		pauseButton = pauseButton.GetComponent<Button> ();
	}

	void Update () {

		//Pause the game when playing.
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause ();
		}
	}

	public void Pause(){
		if (this.name == "Player") {
			GameObject.Find ("Player(Clone)").GetComponent<PlayerPauseScript> ().Pause ();
		} 
		else {

			if (Time.timeScale == 0) {
				GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = false;
				Time.timeScale = 1;
				pauseCanvas.gameObject.SetActive (false);
				pauseButton.image.overrideSprite = pause;
			} else {
				GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = true;
				Time.timeScale = 0;
				pauseCanvas.gameObject.SetActive (true);
				pauseButton.image.overrideSprite = play;
				Debug.Log (this.name);
			}
		}
	}

	public void RestartLevelFromPause(){
		//If the player wants to restart the level, the timeScale can not be 0
		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = false;
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
		Debug.Log(this.name);

	}

	public void GoToMapFromPause(){
		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = false;
		Time.timeScale = 1;
		Application.LoadLevel ("LevelSelection");
	}



}
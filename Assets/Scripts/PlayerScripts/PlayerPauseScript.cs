using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {

	public Canvas pauseCanvas;
	public Canvas startCanvas;
	public Button pauseButton;
	public Sprite pause;
	public Sprite play;

	private int startCounter = 0;

	void Start () {
		pauseCanvas = pauseCanvas.GetComponent<Canvas> ();
		pauseCanvas = GameObject.FindGameObjectWithTag ("PauseCanvas").GetComponent<Canvas> ();
		pauseCanvas.gameObject.SetActive (false);

		startCanvas = startCanvas.GetComponent<Canvas> ();
		startCanvas = GameObject.FindGameObjectWithTag ("StartCanvas").GetComponent<Canvas> ();
		startCanvas.gameObject.SetActive (false);

		pauseButton = pauseButton.GetComponent<Button> ();
	}

	void Update () {

		if(startCounter == 0){
			startCounter++;
			StartCoroutine(PauseBeginning());
		}
		startCanvas.gameObject.SetActive (false);
		//Pause the game when playing.
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause ();
		}
	}

	//Make the scene start after 2 seconds
	private IEnumerator PauseBeginning() {

		Time.timeScale = 0.1f;
		float pauseEndTime = Time.realtimeSinceStartup + 4;
		while (Time.realtimeSinceStartup < pauseEndTime) {
			Debug.Log ("TimeScale is: " + Time.timeScale);
			startCanvas.gameObject.SetActive (true);
			yield return 0;
		}
		startCanvas.gameObject.SetActive (false);
		Time.timeScale = 1;
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
			}
		}
	}

	public void RestartLevelFromPause(){
		//If the player wants to restart the level, the timeScale can not be 0
		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = false;
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);

	}

	public void GoToMapFromPause(){
		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused = false;
		Time.timeScale = 1;
		Application.LoadLevel ("LevelSelection");
	}



}
using UnityEngine;
using System.Collections;

public class FirstSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void pressContinue() {
		Application.LoadLevel ("PirateTalk");
	}

	public void pressSkip () {
		Application.LoadLevel ("LevelSelection");
	}
}

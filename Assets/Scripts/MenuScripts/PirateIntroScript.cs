using UnityEngine;
using System.Collections;


public class PirateIntroScript : MonoBehaviour {

	public Canvas firstSentence;
	public Canvas secondSentence;


	// Use this for initialization
	void Start () {
		AudioListener.volume = 1.0f;
		firstSentence.enabled = true;
		secondSentence.enabled = false;
		StartCoroutine ("wait");

	}

	IEnumerator wait() {
		yield return new WaitForSeconds(3f);
		firstSentence.enabled = false;
		secondSentence.enabled = true;
	}


	public void pressContinue() {
		Application.LoadLevel ("OctoTalk");
	}

	public void pressSkip () {
		Application.LoadLevel ("LevelSelection");
	}
}

using UnityEngine;
using System.Collections;


public class PirateIntroScript : MonoBehaviour {

	public Canvas firstSentence;
	public Canvas secondSentence;


	// Use this for initialization
	void Start () {


		firstSentence.enabled = true;
		secondSentence.enabled = false;
		StartCoroutine ("wait");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator wait() {
		yield return new WaitForSeconds(3f);
		firstSentence.enabled = false;
		secondSentence.enabled = true;
	}


	public void pressContinue() {
		Application.LoadLevel ("OctoSpeech");
	}
}

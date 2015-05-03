using UnityEngine;
using System.Collections;

public class OctoIntroScript : MonoBehaviour {

	public Canvas firstSentence;
	public Canvas secondSentence;

	// Use this for initialization
	void Start () {
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
		Application.LoadLevel ("LevelSelection");
	}
}

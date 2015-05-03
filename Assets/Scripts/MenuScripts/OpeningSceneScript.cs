using UnityEngine;
using System.Collections;

public class OpeningSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine ("wait");

	}
	
	// Update is called once per frame
	IEnumerator wait () {
		
		yield return new WaitForSeconds(3);
			Application.LoadLevel ("MainMenu");

	}
}

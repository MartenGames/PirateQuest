using UnityEngine;
using System.Collections;

public class CreditsScripts : MonoBehaviour {

	public GameObject creditsCamera;
	public float cameraSpeed;

	// Update is called once per frame
	void Update () {

		//Move the camera down for the end credits
		creditsCamera.transform.Translate (Vector3.up * Time.deltaTime * cameraSpeed);
		StartCoroutine ("waitFor");
	}

	IEnumerator waitFor () {

		yield return new WaitForSeconds (16);
		Application.LoadLevel ("MainMenu");
	}
}

using UnityEngine;
using System.Collections;

public class WaitToStartScript : MonoBehaviour {

	public Canvas startCanvas;
	private float waitTime = 0.2f;
	private float startTime = 0.0f;
	// Use this for initialization
	void Start () {
		startTime = Time.time + waitTime;
		startCanvas = startCanvas.GetComponent<Canvas> ();
		startCanvas = GameObject.FindGameObjectWithTag ("StartCanvas").GetComponent<Canvas> ();
		startCanvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime > Time.time) {
			Debug.Log ("Stop");
			Time.timeScale = 0.1f;
			startCanvas.gameObject.SetActive(true);
		} else {
			startCanvas.gameObject.SetActive(false);
			Debug.Log ("Start");
			Time.timeScale = 1;
		}
	}
}

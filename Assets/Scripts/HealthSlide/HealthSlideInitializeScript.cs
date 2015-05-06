using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSlideInitializeScript : MonoBehaviour {

	public Slider healthSlider;


	void Start () {
		Debug.Log ("Does this happen\n");
		Debug.Log (healthSlider.maxValue);
		healthSlider.maxValue = GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().health + 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

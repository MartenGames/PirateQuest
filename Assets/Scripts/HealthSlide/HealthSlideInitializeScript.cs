using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSlideInitializeScript : MonoBehaviour {

	public Slider healthSlider;


	void Start () {
		healthSlider.maxValue = GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().health + 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	public bool secondCannon = false;
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void PressMultiCannons(){
		Debug.Log ("PressMultiCannons in StoringVarScript");
		secondCannon = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	public bool secondCannon = false;
	public bool increaseFirerate_1 = false;
	public bool increaseHealth_1 = false;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetMultiCannonsTrue(){
		Debug.Log ("PressMultiCannons in StoringVarScript");
		secondCannon = true;
	}

	public void PressIncreaseFirerate(){
		Debug.Log ("PressIncreaseFirerate in StoringVarScript");
		increaseFirerate_1 = true;
	}

	public void PressIncreaseHealth(){
		Debug.Log ("PressIncreaseHealth in StoringVarScript");
		increaseHealth_1 = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

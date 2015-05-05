using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	public bool secondCannon = false;
	public bool increaseFirerate_1 = false;
	public int health = 0;

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

//	public int SetIncreaseHealth(){
//		return health;
//	}

	// Update is called once per frame
	void Update () {
	
	}
}

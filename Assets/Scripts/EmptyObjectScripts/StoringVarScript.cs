using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	public bool secondCannon = false;
	public bool increaseFirerate_1 = false;
	public int health = 0;
	public int damage = 1;
	public int goldAmount = 0;
	public int currentLevelGoldAmount = 0;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetMultiCannonsTrue(){
		Debug.Log ("PressMultiCannons in StoringVarScript");
		secondCannon = true;
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}

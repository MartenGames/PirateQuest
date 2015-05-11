using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	public bool secondCannon = false;
	public int health = 0;
	public int damage = 1;
	public int goldAmount = 0;
	public float fireRate = 0;
	public int currentLevelGoldAmount = 0;
	public int currentLevel;

	//Prices in upgrade store
	public int healthPrice = 200;
	public int damagePrice = 500;
	public int fireRatePrice = 500;
	public int secondCannonPrice = 1000;

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

using UnityEngine;
using System.Collections;

public class StoringVarScript : MonoBehaviour {

	//Variables for the player
	public bool secondCannon = true;
	public bool AllowedToWin = true;
	public int health = 0;
	public int damage = 1;
	public int goldAmount = 0;
	public float speed = 0;
	public float acceleration = 0;
	public float rotateSpeed = 0;
	public float fireRate = 0;
	public int currentLevelGoldAmount = 0;
	public int currentLevel;
	public int attackDamage = 25;

	//Variables to determine the highscore
	public int numberOfDeaths = 0;
	public int totalAmountOfGold = 0;
	public float totalAmountOfPlayTime = 0;

	//Prices in upgrade store
	public int healthPrice = 200;
	public int damagePrice = 500;
	public int fireRatePrice = 500;
	public int secondCannonPrice = 1000;
	public int speedPrice = 500;


	//Counter to know how many times a item has been upgrated
	public int healthCounter = 0;
	public int damageCounter = 0;
	public int fireRateCounter = 0;
	public int secondCannonCounter = 0;
	public int speedCounter = 0;

	//Is the game paused or not
	public bool isPaused = false;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void SetMultiCannonsTrue(){
		secondCannon = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

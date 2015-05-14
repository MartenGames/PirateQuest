using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeScript : MonoBehaviour {

	/*public Canvas playerShip;
	public Canvas headline;
	public Canvas attack;
	public Canvas defence;*/

	public Button damageButton;
	public Button firerateButton;
	public Button multiCannonsButton;
	public Button armourButton;
	public Button speedButton;
	public Button continueButton;
	public Text MoneySignal;

	//Stats for the player to show in upgrade store
	public Text playerHealth;
	public Text playerDamage;
	public Text playerNumberOfCannons;
	public Text playerFireRate;
	public Text playerSpeed;

	//Text for prices of upgrades in upgrade store
	public Text healthPriceText;
	public Text damagePriceText;
	public Text fireRatePriceText;
	public Text secondCannonPriceText;
	public Text speedPriceText;

	//Prices of upgrades
	public int healthPrice;
	public int damagePrice;
	public int fireRatePrice;
	public int secondCannonPrice;
	public int speedPrice;

	public AudioClip upgradeSound;
	public AudioClip errorSound;

	GameObject emptyObject;

	DamageHandlerPlayerScript player;
	// Use this for initialization

	void Awake () {
		 emptyObject = GameObject.Find ("EmptyObject(Clone)");

		healthPrice = emptyObject.GetComponent<StoringVarScript> ().healthPrice;
		damagePrice = emptyObject.GetComponent<StoringVarScript> ().damagePrice;
		fireRatePrice = emptyObject.GetComponent<StoringVarScript> ().fireRatePrice;
		secondCannonPrice = emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice;
		speedPrice = emptyObject.GetComponent<StoringVarScript> ().speedPrice;
	}

	void Start () {

		//Initalize the buttons and enable them
		damageButton = damageButton.GetComponent<Button> ();
		firerateButton = firerateButton.GetComponent<Button> ();
		armourButton = armourButton.GetComponent<Button> ();
		multiCannonsButton = multiCannonsButton.GetComponent<Button> ();
		speedButton = speedButton.GetComponent<Button> ();

		continueButton = continueButton.GetComponent<Button> ();
		MoneySignal = MoneySignal.GetComponent<Text> ();



		/*
		damageButton.enabled = true;
		firerateButton.enabled = true;
		armourButton.enabled = true;
		continueButton.enabled = true;
		multiCannonsButton.enabled = true;*/
		MoneySignal.enabled = false;
	
	}

	public void PressContinueButton(){
		Application.LoadLevel ("LevelSelection");
	}

	public void PressMultiCannons(){
		//If the player does not have enough gold
		if (emptyObject.GetComponent<StoringVarScript> ().goldAmount < secondCannonPrice) {
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		} 
		//If the player has enough gold.
		else {
			//The player can not upgrade again
			if(emptyObject.GetComponent<StoringVarScript> ().secondCannonCounter >= 1) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//normal upgrade
			else {
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				MoneySignal.enabled = false;
				emptyObject.GetComponent<StoringVarScript> ().SetMultiCannonsTrue ();
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= secondCannonPrice;
				emptyObject.GetComponent<StoringVarScript> ().secondCannonCounter++;

			}
		}
	}

	public void PressIncreaseHealth(){
		if (emptyObject.GetComponent<StoringVarScript> ().goldAmount < healthPrice) {
			if (emptyObject.GetComponent<StoringVarScript> ().healthCounter >= 2) {
				MoneySignal.enabled = false;
			}
			else {
				MoneySignal.enabled = true;
			}
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
		} 
		else {
			//When the player can not upgrade this item further.
			if (emptyObject.GetComponent<StoringVarScript> ().healthCounter >= 2) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//normal upgrade.
			else {
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				MoneySignal.enabled = false;
				emptyObject.GetComponent<StoringVarScript> ().health += 25;
				emptyObject.GetComponent<StoringVarScript> ().healthPrice *= 2;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= healthPrice;
				emptyObject.GetComponent<StoringVarScript> ().healthCounter++;
			}
		}

	}

	public void PressIncreaseDamage(){
		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < damagePrice){
			if (emptyObject.GetComponent<StoringVarScript> ().damageCounter >= 2) {
				MoneySignal.enabled = false;
			}
			else {
				MoneySignal.enabled = true;
			}
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
		}
		else {
			//When the player can not upgrade this item further.
			if (emptyObject.GetComponent<StoringVarScript> ().damageCounter >= 2) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//Normal upgrade
			else{
				emptyObject.GetComponent<StoringVarScript> ().damagePrice *= 2;
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				emptyObject.GetComponent<StoringVarScript> ().damage += 1;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= damagePrice;
				emptyObject.GetComponent<StoringVarScript> ().damageCounter++;
			}
			MoneySignal.enabled = false;
		}
	}

	public void PressIncreaseFireRate(){

		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < fireRatePrice){
			if (emptyObject.GetComponent<StoringVarScript> ().fireRateCounter >= 2) {
				MoneySignal.enabled = false;
			}
			else {
				MoneySignal.enabled = true;
			}
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
		}
		else {
			//When the player can not upgrade this item further.
			if (emptyObject.GetComponent<StoringVarScript> ().fireRateCounter >= 2) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//normal upgrade
			else{
				emptyObject.GetComponent<StoringVarScript> ().fireRatePrice *= 2;
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				MoneySignal.enabled = false;
				emptyObject.GetComponent<StoringVarScript> ().fireRate += 0.2f;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= fireRatePrice;
				emptyObject.GetComponent<StoringVarScript> ().fireRateCounter++;
			}
		}
	}

	public void PressIncreaseSpeed(){
		
		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < speedPrice){
			if (emptyObject.GetComponent<StoringVarScript> ().speedCounter >= 2) {
				MoneySignal.enabled = false;
			}
			else {
				MoneySignal.enabled = true;
			}
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
		}
		else {
			//When the player can not upgrade this item further.
			if (emptyObject.GetComponent<StoringVarScript> ().speedCounter >= 2) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//Normal upgrade
			else{
				emptyObject.GetComponent<StoringVarScript> ().speedPrice *= 2;
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				MoneySignal.enabled = false;
				emptyObject.GetComponent<StoringVarScript> ().speed += 0.01f;
				emptyObject.GetComponent<StoringVarScript> ().acceleration += 0.015f;
				emptyObject.GetComponent<StoringVarScript> ().rotateSpeed += 0.25f;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= speedPrice;
				emptyObject.GetComponent<StoringVarScript> ().speedCounter++;
			}
		}
	}


	// Update is called once per frame
	void Update () {


		int gold = emptyObject.GetComponent<StoringVarScript> ().goldAmount;

		//Print out the stats of the player.	
		playerHealth.text = "Health: " + (emptyObject.GetComponent<StoringVarScript> ().health + 100);
		playerDamage.text = "Damage: " + emptyObject.GetComponent<StoringVarScript> ().damage;
		playerFireRate.text = "Firerate: " + (1 - emptyObject.GetComponent<StoringVarScript> ().fireRate) + " second";
		playerSpeed.text = "Speed: " + (emptyObject.GetComponent<StoringVarScript> ().speed + 0.02f);
		if (emptyObject.GetComponent<StoringVarScript> ().secondCannon) {
			playerNumberOfCannons.text = "Number of Cannons: 2";
		} else {
			playerNumberOfCannons.text = "Number of Cannons: 1";
		}

		//Constantly be on top of what the current price is
		healthPrice = emptyObject.GetComponent<StoringVarScript> ().healthPrice;
		damagePrice = emptyObject.GetComponent<StoringVarScript> ().damagePrice;
		fireRatePrice = emptyObject.GetComponent<StoringVarScript> ().fireRatePrice;
		secondCannonPrice = emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice;
		speedPrice = emptyObject.GetComponent<StoringVarScript> ().speedPrice;


		//color of the increase health text
		if (gold < healthPrice) {
			//The color if the player has reached maximum.
			if (emptyObject.GetComponent<StoringVarScript> ().healthCounter >= 2) {
				healthPriceText.color = Color.black;
			}
			else{
				healthPriceText.color = Color.red;
			}
		}
		//color of the increase damage text
		if (gold < damagePrice) {
			//The color if the player has reached maximum.
			if (emptyObject.GetComponent<StoringVarScript> ().damageCounter >= 2) {
				damagePriceText.color = Color.black;
			}
			else{
				damagePriceText.color = Color.red;
			}
		}
		//color of the fireRate text
		if (gold < fireRatePrice) {
			if (emptyObject.GetComponent<StoringVarScript>().fireRateCounter >= 2){
				fireRatePriceText.color = Color.black;
			}
			else{
				fireRatePriceText.color = Color.red;
			}
		}
		//color of the second cannon text
		if (gold < secondCannonPrice) {
			if (emptyObject.GetComponent<StoringVarScript>().secondCannonCounter >= 1){
				secondCannonPriceText.color = Color.black;
			}
			else{
				secondCannonPriceText.color = Color.red;
			}
		}
		//color of the speed text
		if (gold < speedPrice) {
			if (emptyObject.GetComponent<StoringVarScript>().speedCounter >= 2){
				speedPriceText.color = Color.black;
			}
			else{
				speedPriceText.color = Color.red;
			}
		}

		//The text that the player sees in the upgrade store
		//increase damage
		if (emptyObject.GetComponent<StoringVarScript> ().damageCounter >= 2) {
			damagePriceText.text = "Increase Damage of Cannon: \n" + "Reached maximum!";
			damagePriceText.color = Color.black;
		} 
		else {
			damagePriceText.text = "Increase Damage of Cannon: \n" + emptyObject.GetComponent<StoringVarScript> ().damagePrice + " Coins";
		}

		//increase health
		if (emptyObject.GetComponent<StoringVarScript> ().healthCounter >= 2) {
			healthPriceText.text = "Increase Health: \n" + "Reached maximum!";
			healthPriceText.color = Color.black;
		}
		else {
			healthPriceText.text = "Increase Health: \n" + emptyObject.GetComponent<StoringVarScript> ().healthPrice + " Coins";
		}

		//Add cannons to the player's ship
		if (emptyObject.GetComponent<StoringVarScript> ().secondCannonCounter >= 1) {
			secondCannonPriceText.text = "Add cannon to the ship: \n" + "Reached maximum!";
			secondCannonPriceText.color = Color.black;
		} 
		else {
			secondCannonPriceText.text = "Add cannon to the ship: \n" + emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice + " Coins";
		}

		//increase fireRate
		if (emptyObject.GetComponent<StoringVarScript> ().fireRateCounter >= 2) {
			fireRatePriceText.text = "Increase Firerate: \n" + "Reached mamimum!";
			fireRatePriceText.color = Color.black;
		} 
		else {
			fireRatePriceText.text = "Increase Firerate: \n" + emptyObject.GetComponent<StoringVarScript> ().fireRatePrice + " Coins";
		}

		//increase speed
		if (emptyObject.GetComponent<StoringVarScript> ().speedCounter >= 2) {
			speedPriceText.text = "Increase Speed: \n" + "Reached maximum!";
			speedPriceText.color = Color.black;
		} 
		else {
			speedPriceText.text = "Increase Speed: \n" + emptyObject.GetComponent<StoringVarScript> ().speedPrice + " Coins";
		}

	}
}

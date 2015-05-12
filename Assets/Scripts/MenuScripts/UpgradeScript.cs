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

	//Counter to know how many times a item has been upgrated
	private int healthCounter = 0;
	private int damageCounter = 0;
	private int fireRateCounter = 0;
	private int secondCannonCounter = 0;
	private int speedCounter = 0;
	
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

		if (emptyObject.GetComponent<StoringVarScript> ().goldAmount < secondCannonPrice) {
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		} else {
			emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice *= 2;	
			AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
			MoneySignal.enabled = false;
			emptyObject.GetComponent<StoringVarScript> ().SetMultiCannonsTrue ();
			emptyObject.GetComponent<StoringVarScript> ().goldAmount -= secondCannonPrice;
		}
	}

	public void PressIncreaseHealth(){
		if (emptyObject.GetComponent<StoringVarScript> ().goldAmount < healthPrice) {
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		} else {

		
			AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
			MoneySignal.enabled = false;
			emptyObject.GetComponent<StoringVarScript> ().health += 25;
			emptyObject.GetComponent<StoringVarScript> ().healthPrice *= 2;
			emptyObject.GetComponent<StoringVarScript> ().goldAmount -= healthPrice;
		}

	}

	public void PressIncreaseDamage(){
		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < damagePrice){
			if (damageCounter >= 3) {
				MoneySignal.enabled = false;
			}
			else {
				MoneySignal.enabled = true;
			}
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
		}
		else {
			//When the player can not upgrade this item further.
			if (damageCounter >= 3) {
				AudioSource.PlayClipAtPoint(errorSound, transform.position);
			}
			//the last time the player can upgrade this item.
			else if (damageCounter == 2){
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				emptyObject.GetComponent<StoringVarScript> ().damage += 1;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= damagePrice;
				damageCounter++;
			}
			//Normal upgrade
			else{
				emptyObject.GetComponent<StoringVarScript> ().damagePrice *= 2;
				AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
				emptyObject.GetComponent<StoringVarScript> ().damage += 1;
				emptyObject.GetComponent<StoringVarScript> ().goldAmount -= damagePrice;
				damageCounter++;
			}
			MoneySignal.enabled = false;
		}
	}

	public void PressIncreaseFireRate(){

		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < fireRatePrice){
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		}
		else {
			emptyObject.GetComponent<StoringVarScript> ().fireRatePrice *= 2;
			AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
			MoneySignal.enabled = false;
			emptyObject.GetComponent<StoringVarScript> ().fireRate += 0.2f;
			emptyObject.GetComponent<StoringVarScript> ().goldAmount -= fireRatePrice;
		}
	}

	public void PressIncreaseSpeed(){
		
		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < speedPrice){
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		}
		else {
			emptyObject.GetComponent<StoringVarScript> ().speedPrice *= 2;
			AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
			MoneySignal.enabled = false;
			emptyObject.GetComponent<StoringVarScript> ().speed += 0.05f;
			emptyObject.GetComponent<StoringVarScript> ().acceleration += 0.025f;
			emptyObject.GetComponent<StoringVarScript> ().rotateSpeed += 0.25f;
			emptyObject.GetComponent<StoringVarScript> ().goldAmount -= speedPrice;
		}
	}


	// Update is called once per frame
	void Update () {


		int gold = emptyObject.GetComponent<StoringVarScript> ().goldAmount;

		//Print out the stats of the player.	
		playerHealth.text = "Health: " + (emptyObject.GetComponent<StoringVarScript> ().health + 100);
		playerDamage.text = "Damage: " + emptyObject.GetComponent<StoringVarScript> ().damage;
		playerFireRate.text = "Firerate: " + (1 - emptyObject.GetComponent<StoringVarScript> ().fireRate) + " second";
		playerSpeed.text = "Speed: " + (emptyObject.GetComponent<StoringVarScript> ().speed + 0.05f);
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



		if (gold < healthPrice) {
			healthPriceText.color = Color.red;
		}
		if (gold < damagePrice) {
			//The color if the player has reached maximum.
			if (damageCounter >= 3) {
				damagePriceText.color = Color.black;
			}
			else{
				damagePriceText.color = Color.red;
			}
		}
		if (gold < fireRatePrice) {
			fireRatePriceText.color = Color.red;
		}
		if (gold < secondCannonPrice) {
			secondCannonPriceText.color = Color.red;
		}
		if (gold < speedPrice) {
			speedPriceText.color = Color.red;
		}

		//The text that the player sees in the upgrade store
		if (damageCounter >= 3) {
			damagePriceText.color = Color.black;
			damagePriceText.text = "Increase Damage of Cannon: \n" + "Reached maximum!";
		} 
		else {
			damagePriceText.text = "Increase Damage of Cannon: \n" + emptyObject.GetComponent<StoringVarScript> ().damagePrice + " Coins";
		}

		healthPriceText.text = "Increase Health: \n" + emptyObject.GetComponent<StoringVarScript> ().healthPrice + " Coins";
		fireRatePriceText.text = "Increase Firerate: \n" + emptyObject.GetComponent<StoringVarScript> ().fireRatePrice + " Coins";
		secondCannonPriceText.text = "Add cannon to the ship: \n" + emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice + " Coins";
		speedPriceText.text = "Increase Speed: \n" + emptyObject.GetComponent<StoringVarScript> ().speedPrice + " Coins";

	}
}

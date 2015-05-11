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
	public Button continueButton;
	public Text MoneySignal;

	//Stats for the player to show in upgrade store
	public Text playerHealth;
	public Text playerDamage;
	public Text playerNumberOfCannons;
	public Text playerFireRate;

	//Text for prices of upgrades in upgrade store
	public Text healthPriceText;
	public Text damagePriceText;
	public Text fireRatePriceText;
	public Text secondCannonPriceText;

	//Prices of upgrades
	public int healthPrice;
	public int damagePrice;
	public int fireRatePrice;
	public int secondCannonPrice;


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
	}

	void Start () {

		//Initalize the buttons and enable them
		damageButton = damageButton.GetComponent<Button> ();
		firerateButton = firerateButton.GetComponent<Button> ();
		armourButton = armourButton.GetComponent<Button> ();
		multiCannonsButton = multiCannonsButton.GetComponent<Button> ();
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

	public void PressIncreaseDAmage(){

		if(emptyObject.GetComponent<StoringVarScript> ().goldAmount < damagePrice){
			AudioSource.PlayClipAtPoint(errorSound, transform.position);
			MoneySignal.enabled = true;
		}
		else {
			emptyObject.GetComponent<StoringVarScript> ().damagePrice *= 2;
			AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
			MoneySignal.enabled = false;
			emptyObject.GetComponent<StoringVarScript> ().damage += 1;
			emptyObject.GetComponent<StoringVarScript> ().goldAmount -= damagePrice;
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


	// Update is called once per frame
	void Update () {


		int gold = emptyObject.GetComponent<StoringVarScript> ().goldAmount;

		//Print out the stats of the player.	
		playerHealth.text = "Health: " + (emptyObject.GetComponent<StoringVarScript> ().health + 100);
		playerDamage.text = "Damage: " + emptyObject.GetComponent<StoringVarScript> ().damage;
		playerFireRate.text = "Firerate: " + (1 - emptyObject.GetComponent<StoringVarScript> ().fireRate) + " second";
		if (emptyObject.GetComponent<StoringVarScript> ().secondCannon) {
			playerNumberOfCannons.text = "Number of Cannons: 1";
		} else {
			playerNumberOfCannons.text = "Number of Cannons: 1";
		}




		if (gold < healthPrice) {
			healthPriceText.color = Color.red;
		}
		if (gold < damagePrice) {
			damagePriceText.color = Color.red;
		}
		if (gold < fireRatePrice) {
			fireRatePriceText.color = Color.red;
		}
		if (gold < secondCannonPrice) {
			secondCannonPriceText.color = Color.red;
		}
		healthPriceText.text = "Increase Health: \n" + emptyObject.GetComponent<StoringVarScript> ().healthPrice + " Coins";
		damagePriceText.text = "Increase Damage of Cannon: \n" + emptyObject.GetComponent<StoringVarScript> ().damagePrice + " Coins";
		fireRatePriceText.text = "Increase Firerate: \n" + emptyObject.GetComponent<StoringVarScript> ().fireRatePrice + " Coins";
		secondCannonPriceText.text = "Add cannon to the ship: \n" + emptyObject.GetComponent<StoringVarScript> ().secondCannonPrice + " Coins";

	}
}

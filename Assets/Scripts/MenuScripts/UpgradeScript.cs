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


	DamageHandlerPlayerScript player;
	// Use this for initialization
	void Start () {

		//Initialize the buttons and canvas

		/*playerShip = playerShip.GetComponent<Canvas> ();
		headline = headline.GetComponent<Canvas> ();
		attack = attack.GetComponent<Canvas> ();
		defence = defence.GetComponent<Canvas> ();*/

		damageButton = damageButton.GetComponent<Button> ();
		firerateButton = firerateButton.GetComponent<Button> ();
		armourButton = armourButton.GetComponent<Button> ();
		multiCannonsButton = multiCannonsButton.GetComponent<Button> ();
		continueButton = continueButton.GetComponent<Button> ();
		MoneySignal = MoneySignal.GetComponent<Text> ();

		//make everything visable

		/*playerShip.enabled = true;
		headline.enabled = true;
		attack.enabled = true;
		defence.enabled = true;*/

		damageButton.enabled = true;
		firerateButton.enabled = true;
		armourButton.enabled = true;
		continueButton.enabled = true;
		multiCannonsButton.enabled = true;
		MoneySignal.enabled = false;
	
	}

	public void PressContinueButton(){
		Application.LoadLevel ("LevelSelection");
	}

	public void PressMultiCannons(){

		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		if (go.GetComponent<StoringVarScript> ().goldAmount < 1500) {
			MoneySignal.enabled = true;
		} else {
			MoneySignal.enabled = false;
			go.GetComponent<StoringVarScript> ().SetMultiCannonsTrue ();
			go.GetComponent<StoringVarScript> ().goldAmount -= 1500;
		}
	}

	public void PressIncreaseHealth(){
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		if (go.GetComponent<StoringVarScript> ().goldAmount < 200) {
			MoneySignal.enabled = true;
		} else {
			MoneySignal.enabled = false;
			go.GetComponent<StoringVarScript> ().health += 25;
			go.GetComponent<StoringVarScript> ().goldAmount -= 200;
		}

	}

	public void PressIncreaseDAmage(){
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		if(go.GetComponent<StoringVarScript> ().goldAmount < 200){
			MoneySignal.enabled = true;
		}
		else {
			MoneySignal.enabled = false;
			go.GetComponent<StoringVarScript> ().damage += 1;
			go.GetComponent<StoringVarScript> ().goldAmount -= 200;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}

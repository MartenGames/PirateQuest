using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenuScript : MonoBehaviour {

	//Variables needed for the main menu

	public Canvas InfoMenu;
	public Button PlayButton;
	public Button ExitButton;
	public Button InfoButton;

	
	// Use this for initialization
	void Start () {

		//Initialize the buttons and canvas
		InfoMenu = InfoMenu.GetComponent<Canvas> ();
		InfoButton = InfoButton.GetComponent<Button> ();
		PlayButton = PlayButton.GetComponent<Button> ();
		ExitButton = ExitButton.GetComponent<Button> ();

		InfoButton.enabled = false;
		PlayButton.enabled = true;
		ExitButton.enabled = true;
		InfoButton.enabled = true;
	}


	public void PressPlay () {
		//dostuff
	}


	//Pop up the Info Menu when you press How To
	public void PressHowTo () {

		InfoMenu.enabled = true;
		PlayButton.enabled = false;
		ExitButton.enabled = false;
		InfoButton.enabled = false;


	}

	//Function to enable the button to go back to main menu from the info menu
	public void QuitInfoMenu () {

		InfoMenu.enabled = false;
		PlayButton.enabled = true;
		ExitButton.enabled = true;
		InfoButton.enabled = true;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}

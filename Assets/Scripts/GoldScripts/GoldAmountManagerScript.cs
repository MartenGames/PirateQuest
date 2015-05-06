using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldAmountManagerScript : MonoBehaviour 
{
	public static int goldAmount; //The player's amount of gold

	Text text;

	GameObject emptyObject;

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Access the storing variable script to access the players goldAmount
		emptyObject = GameObject.Find ("EmptyObject(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

		// Set the displayed text to be the word "Gold: " followed by the score value.
		text.text = "Gold: " + (emptyObject.GetComponent<StoringVarScript>().goldAmount + 
		                        emptyObject.GetComponent<StoringVarScript>().currentLevelGoldAmount);
	}
}

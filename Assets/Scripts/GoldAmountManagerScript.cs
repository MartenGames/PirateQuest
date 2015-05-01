using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldAmountManagerScript : MonoBehaviour 
{
	public static int goldAmount; //The player's amount of gold

	Text text;

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		goldAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Set the displayed text to be the word "Gold: " followed by the score value.
		text.text = "Gold: " + goldAmount;
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreScript : MonoBehaviour {


	public Text highScoreText;

	int numberOfDeaths;
	float playTime;
	int goldAmount;

	// Use this for initialization
	void Start () {
		GameObject stats = GameObject.Find ("EmptyObject(Clone)");

		numberOfDeaths = stats.GetComponent<StoringVarScript> ().numberOfDeaths;
		playTime = stats.GetComponent<StoringVarScript> ().totalAmountOfPlayTime;
		goldAmount = stats.GetComponent<StoringVarScript> ().totalAmountOfGold;


		highScoreText.text = "Congratulations! \n Your Score is: " + (goldAmount - (numberOfDeaths * 20) - playTime);

	}

	void EndGame () {
		Application.LoadLevel ("EndCredits");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

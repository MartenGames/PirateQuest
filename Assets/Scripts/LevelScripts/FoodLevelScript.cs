using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FoodLevelScript : MonoBehaviour {


	public Text timerText;
	public float timer;
	bool won;
	GameObject player;

	// Use this for initialization
	void Start () {
		won = false;
		player = GameObject.Find ("Player(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

		timerText.text = "" + timer;

		if (GameObject.FindWithTag ("Food") == null) {
			won = true;
		}

		if (timer > 0 && !won) {
			timer -= Time.deltaTime;
		}

		if (timer <= 0) {
			timer = 0;
			if(player != null) {
				player.GetComponent<PlayerHealthScript>().currentHealth = 0;
			}
		}

	}
}	

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FoodLevelScript : MonoBehaviour {


	public Text timerText;
	public float timer;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

		timerText.text = "" + timer;

		if (timer > 0) {
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

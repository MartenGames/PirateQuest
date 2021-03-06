﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHandlerPlayerScript : MonoBehaviour {

	public int attackDamage;
	public float invulnerabilityTimer = 0;
	public AudioClip playerDies2;
	public AudioClip playerGetHit1;
	public Canvas defeatCanvas;
	public Canvas winningCanvas;
	public Button restartLevel;
	public Button goToUpgradeStore;
	public Button goToMap;
	//public bool secondCannon = false;
	private Slider mapSlider;
	Material material;
	Color color;
	PlayerHealthScript playerHealth;
	int layer;

	
	void Start() {

		DontDestroyOnLoad (GameObject.Find("EmptyObject"));

		GameObject go = GameObject.Find ("HealthSlider");
		mapSlider = go.GetComponent<Slider> ();

		playerHealth = GetComponent <PlayerHealthScript> ();

		defeatCanvas = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Canvas> ();
		defeatCanvas.gameObject.SetActive (false);

		winningCanvas = GameObject.FindGameObjectWithTag("WinningCanvas").GetComponent<Canvas> ();
		winningCanvas.gameObject.SetActive (false);

		restartLevel = restartLevel.GetComponent<Button> ();
		goToUpgradeStore = goToUpgradeStore.GetComponent<Button> ();
		goToMap = goToMap.GetComponent<Button> ();

		GameObject cannon2 = GameObject.Find ("Cannon2");
		cannon2.SetActive (GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript>().secondCannon);

		GameObject cannon = GameObject.Find ("Cannon");
		cannon.SetActive (true);

		layer = gameObject.layer;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;

		attackDamage = GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript>().attackDamage;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.name == "EnemyBullet(Clone)") || (other.gameObject.name == "BossBullet(Clone)") || (other.gameObject.tag == "JellyFish")) {
			playerHealth.TakeDamage (attackDamage);
			invulnerabilityTimer = 2.0f;
			gameObject.layer = 11;
			material.color = Color.red;
			AudioSource.PlayClipAtPoint (playerGetHit1, transform.position);
		} else if (other.gameObject.name == "EnemyEnergyBall(Clone)") {
			playerHealth.TakeDamage (attackDamage + 25);
			invulnerabilityTimer = 2.0f;
			gameObject.layer = 11;
			material.color = Color.red;
			AudioSource.PlayClipAtPoint (playerGetHit1, transform.position);
		} else if (other.gameObject.name == "EnemyFireBall(Clone)") {
			playerHealth.TakeDamage (attackDamage + 50);
			invulnerabilityTimer = 2.0f;
			gameObject.layer = 11;
			material.color = Color.red;
			AudioSource.PlayClipAtPoint (playerGetHit1, transform.position);
		}
	}
	
	void Update() {
		invulnerabilityTimer -= Time.deltaTime;

		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().totalAmountOfPlayTime += Time.deltaTime;
		
		if (invulnerabilityTimer <= 0) {
			gameObject.layer = layer;
			material.color = color;
		} else if (1.75f < invulnerabilityTimer && invulnerabilityTimer <= 2.0f) {
			material.color = Color.red;
		} else if (1.5f < invulnerabilityTimer && invulnerabilityTimer <= 1.75f) {
			material.color = color;
		} else if (1.25f < invulnerabilityTimer && invulnerabilityTimer <= 1.5f) {
			material.color = Color.red;
		} else if (1.0f < invulnerabilityTimer && invulnerabilityTimer <= 1.25f) {
			material.color = color;
		} else if (0.75f < invulnerabilityTimer && invulnerabilityTimer <= 1.0f) {
			material.color = Color.red;
		} else if (0.5f < invulnerabilityTimer && invulnerabilityTimer <= 0.75f) {
			material.color = color;
		} else if (0.25f < invulnerabilityTimer && invulnerabilityTimer <= 0.5f) {
			material.color = Color.red;
		} else if (0f < invulnerabilityTimer && invulnerabilityTimer <= 0.25f) {
			material.color = color;
		}

		playerHealth.healthSlider.value = playerHealth.currentHealth;

		mapSlider.value = playerHealth.currentHealth;

		if (playerHealth.currentHealth <= 0) {
			Die ();
		}

		if (GameObject.FindWithTag ("Enemy1") == null && GameObject.FindWithTag ("Enemy2") == null 
		    && GameObject.FindWithTag ("Enemy3") == null && GameObject.FindWithTag ("Enemy4") == null &&
		    GameObject.FindWithTag("Enemy5") == null && GameObject.FindWithTag ("EnemyBoss") == null &&
		    GameObject.FindWithTag("Food") == null) {
			//make the player invinsible when he has killed every enemy
			gameObject.layer = 11;
			GameObject go = GameObject.Find ("EmptyObject(Clone)");
			if(go.GetComponent<StoringVarScript>().AllowedToWin) {
				go.GetComponent<StoringVarScript> ().goldAmount += go.GetComponent<StoringVarScript> ().currentLevelGoldAmount;
				go.GetComponent<StoringVarScript> ().totalAmountOfGold += go.GetComponent<StoringVarScript> ().currentLevelGoldAmount;
				if(GameObject.FindWithTag ("Gold") == null) {
					winningCanvas.gameObject.SetActive(true);
				}
				go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart += go.GetComponent<StoringVarScript> ().currentLevelGoldAmount;
				go.GetComponent<StoringVarScript> ().currentLevelGoldAmount = 0;
			}
		}
	}
	
	void Die() {
		GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().numberOfDeaths += 1;
		Destroy (gameObject);
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmount = 0;
		defeatCanvas.gameObject.SetActive (true);
		AudioSource.PlayClipAtPoint (playerDies2, transform.position);
	}

	public void RestartLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}
		
	public void RestartLevelFromWinning() {
		//Need to set the gold amount for tha last level as 0. So the player will not hold
		//the gold that he collected in the level.
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().goldAmount -= go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart;
		go.GetComponent<StoringVarScript> ().totalAmountOfGold -= go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart;
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart = 0;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void GoToMapDefeat() {
		Application.LoadLevel ("LevelSelection");
	}

	public void GoToMapWin() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		//Every time the player wins,currentLevelGoldAmountForRestart has to be set to 0.
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart = 0;

		if (go.GetComponent<StoringVarScript> ().currentLevel == 10) {
			Application.LoadLevel ("EndSceneOcto");
		} else {
			go.GetComponent<StoringVarScript> ().currentLevel += 1;
			Application.LoadLevel ("LevelSelection");
		}
	}
	
	public void GoToUpgradeStoreWin() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		//Every time the player wins,currentLevelGoldAmountForRestart has to be set to 0.
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart = 0;

		if (go.GetComponent<StoringVarScript> ().currentLevel == 10) {
			Application.LoadLevel ("EndSceneOcto");
		} else {
			go.GetComponent<StoringVarScript> ().currentLevel += 1;
			Application.LoadLevel ("UpgradeStore");
		}
	}

	public void GoTupUpgradeStoreDefeat() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmountForRestart = 0;
		Application.LoadLevel ("UpgradeStore");
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHandlerPlayerScript : MonoBehaviour {

	public int attackDamage = 25;
	public float invulnerabilityTimer = 0;
	public AudioClip sinkShip;
	public Canvas defeatCanvas;
	public Canvas winningCanvas;
	public Button restartLevel;
	public Button goToUpgradeStore;
	public Button goToMap;
	//public bool secondCannon = false;

	private Slider mapSlider;

	// Reference to the player GameObject.
	GameObject player;
	PlayerHealthScript playerHealth;
	int layer;
	
	void Start() {

		DontDestroyOnLoad (GameObject.Find("EmptyObject"));

		GameObject go = GameObject.Find ("HealthSlider");
		mapSlider = go.GetComponent<Slider> ();

		player = GameObject.Find("Player(Clone)");
		playerHealth = player.GetComponent <PlayerHealthScript> ();

		defeatCanvas = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Canvas> ();
		defeatCanvas.gameObject.SetActive (false);

		winningCanvas = GameObject.FindGameObjectWithTag("WinningCanvas").GetComponent<Canvas> ();
		winningCanvas.gameObject.SetActive (false);

		restartLevel = restartLevel.GetComponent<Button> ();
		goToUpgradeStore = goToUpgradeStore.GetComponent<Button> ();
		goToMap = goToMap.GetComponent<Button> ();

		GameObject cannon = GameObject.Find ("Cannon2");
		cannon.SetActive (GameObject.Find("EmptyObject(Clone)").GetComponent<StoringVarScript>().secondCannon);

		layer = gameObject.layer;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "EnemyBullet(Clone)") {
			playerHealth.TakeDamage(attackDamage);
			invulnerabilityTimer = 2f;
			gameObject.layer = 11;
		}
	}
	
	void Update() {
		invulnerabilityTimer -= Time.deltaTime;
		
		if (invulnerabilityTimer <= 0) {
			gameObject.layer = layer;
		}

		playerHealth.healthSlider.value = playerHealth.currentHealth;

		mapSlider.value = playerHealth.currentHealth;

		if (playerHealth.currentHealth <= 0) {
			Die ();
		}

		if ((GameObject.Find ("Enemy(Clone)") == null) && (GameObject.Find ("EnemyBoss(Clone)") == null)) {
			//make the player invinsible when he has killed every enemy
			gameObject.layer = 11;
			GameObject go = GameObject.Find ("EmptyObject(Clone)");
			go.GetComponent<StoringVarScript> ().goldAmount += go.GetComponent<StoringVarScript> ().currentLevelGoldAmount;
			winningCanvas.gameObject.SetActive(true);
			go.GetComponent<StoringVarScript> ().currentLevelGoldAmount = 0;
		}
	}
	
	void Die() {
		Destroy (gameObject);
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmount = 0;
		defeatCanvas.gameObject.SetActive (true);
	}

	public void RestartLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void GoToMapDefeat() {
		Application.LoadLevel ("LevelSelection");
	}

	public void GoToMapWin() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevel += 1;
		Application.LoadLevel ("LevelSelection");
	}



	public void GoToUpgradeStore() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevel += 1;
		Application.LoadLevel ("UpgradeStore");
	}

}

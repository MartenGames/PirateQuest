using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHandlerPlayerScript : MonoBehaviour {
	
	public int health = 2;
	public float invulnerabilityTimer = 0;
	public AudioClip sinkShip;
	public Canvas defeatCanvas;
	public Canvas winningCanvas;
	public Button restartLevel;
	public Button nextLevel;
	public Button goToMap;
	public float xCoordinate;
	public float yCoordinate;
	public bool secondCannon = false;

	// Reference to the player GameObject.
	GameObject player;
	PlayerHealthScript playerHealth;
	int layer;
	
	void Start() {
		if (player == null) {
			GameObject go = GameObject.Find ("Player");
			
			if(go != null) {
				player = go;
				playerHealth = player.GetComponent <PlayerHealthScript> ();
			}
		}

		defeatCanvas = defeatCanvas.GetComponent<Canvas> ();
		winningCanvas = winningCanvas.GetComponent<Canvas> ();
		restartLevel = restartLevel.GetComponent<Button> ();
		nextLevel = nextLevel.GetComponent<Button> ();
		goToMap = goToMap.GetComponent<Button> ();
		defeatCanvas.enabled = false;
		winningCanvas.enabled = false;
		GameObject cannon = GameObject.Find ("Cannon2");
		cannon.SetActive (secondCannon);
		layer = gameObject.layer;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "EnemyBullet(Clone)") {
			health--;
			invulnerabilityTimer = 2f;
			gameObject.layer = 11;
		}
	}
	
	void Update() {
		invulnerabilityTimer -= Time.deltaTime;
		
		if (invulnerabilityTimer <= 0) {
			gameObject.layer = layer;
		}
		
		if (health <= 0) {
			Die ();
		}

		if (GameObject.Find ("Enemy(Clone)") == null) {
			winningCanvas.enabled = true;
		}
	}
	
	void Die() {
		Destroy (gameObject);
		defeatCanvas.enabled = true;
	}

	public void RestartLevel() {
		Debug.Log ("Restart Level!");
		Application.LoadLevel (Application.loadedLevel);
	}

	public void GoToMap() {
		Debug.Log ("Got To Map!");
		Application.LoadLevel (1);
	}

	public void NextLevel() {
		Debug.Log ("Next Level!");
		// Remember to add a final level where you will win the game!
		// Application.LoadLevel (Application.loadedLevel + 1);
	}
}
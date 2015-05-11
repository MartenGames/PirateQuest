using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBossHealthScript : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Slider healthSlider;
	public Text healthText;
	bool isDead;

	void Start () {

		var canvas = this.transform.GetComponentInChildren<Transform> ();

		healthSlider = GameObject.Find ("EnemyBossHealthSlider").GetComponent<Slider>();
		healthText = GameObject.Find ("CurrentHealth").GetComponent<Text> ();

		currentHealth = startingHealth;
		healthSlider.maxValue = currentHealth;
		healthSlider.value = currentHealth;
	}

	void Update () {
		healthText.text = "" + (healthSlider.value * 10);
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death() {
		isDead = true;
	}
}

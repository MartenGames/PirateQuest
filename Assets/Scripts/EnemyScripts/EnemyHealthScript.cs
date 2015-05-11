using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Slider healthSlider;
	bool isDead;

	void Start () {
		var canvas = this.transform.GetComponentInChildren<Transform> ();
		Transform go, go2, go3;

		foreach (Transform child in canvas) {
			go2 = child.FindChild ("HealthUI");
			go3 = go2.FindChild ("HealthSlider");
			healthSlider = go3.GetComponent<Slider>();
		}

		currentHealth = startingHealth;
		healthSlider.maxValue = currentHealth;
		healthSlider.value = currentHealth;
	}

	void Update () {

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

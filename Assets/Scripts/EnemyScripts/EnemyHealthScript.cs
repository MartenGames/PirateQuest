using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	Slider healthSlider;
	Image damageImage;
	bool isDead;
	bool damaged;


	// Use this for initialization
	void Start () {
		var canvas = this.transform.GetComponentInChildren<Transform> ();
		Transform go, go2, go3;

		foreach (Transform child in canvas) {
			Debug.Log ("TEST: " + child.name);
			go = child.FindChild("DamageImage");
			go2 = child.FindChild ("HealthUI");
			go3 = go2.FindChild ("HealthSlider");
			damageImage = go.GetComponent<Image>();
			healthSlider = go3.GetComponent<Slider>();
		}

		currentHealth = startingHealth;
		healthSlider.maxValue = currentHealth;
		healthSlider.value = currentHealth;
		/*
		Debug.Log ("Finally:");
		Debug.Log ("TEST: " + damageImage.name);
		Debug.Log ("TEST: " + damageImage.type);
		Debug.Log ("TEST: " + healthSlider.name);
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount) {
		damaged = true;
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

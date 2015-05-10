using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public GameObject damImg;
	Image damageImage;
	bool isDead;
	bool damaged;
	/*

	// Use this for initialization
	void Start () {
		damageImage = damImg.GetComponent<Image> ();
		currentHealth = startingHealth;
		healthSlider.maxValue = currentHealth;
		healthSlider.value = currentHealth;
		Debug.Log ("TEST: " + damageImage.name);
		Debug.Log ("TEST: " + damageImage.type);
		Debug.Log ("TEST: " + healthSlider.name);
	}
	
	// Update is called once per frame
	void Update () {
		// Vector3 pos = new Vector3 (0, 0, 1);
		//damageImage.transform.position = pos;
		//healthSlider.transform.position = pos;
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
	*/

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBossHealthSliderScript : MonoBehaviour {

	public Slider healthSlider;
	public Text currentHealth;	

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		currentHealth.text = "" + (healthSlider.value * 10);
	}
}

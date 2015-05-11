using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBossHealthSliderScript : MonoBehaviour {

	public Slider healthSlider;
	public Text currentHealth;	

	void Start () {
		//healthSlider.maxValue = GameObject.Find ("EnemyBoss(Clone)").GetComponent<DamageHandlerEnemyBossScript>().health;
	}

	// Update is called once per frame
	void Update () {
		currentHealth.text = "" + healthSlider.value;
	}
}

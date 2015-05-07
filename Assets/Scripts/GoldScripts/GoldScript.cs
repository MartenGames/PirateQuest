using UnityEngine;
using System.Collections;

public class GoldScript : MonoBehaviour {

	//The life time of the gold
	private float lifeTime = 5.0f;
	private float startTime = 0.0f;
	Material material;
	Color color;

	void Start () {
		//set startTime as lifeTime
		startTime = Time.time + lifeTime;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
	}
	
	void Update () {

		//Destroy object when a startTime has passed.
		if(startTime <= Time.time){
			Destroy(gameObject);
		} /*else if (0f < startTime && startTime <= 0.25f) {
			material.color = Color.red;
		} else if (1.5f < startTime && startTime <= 1.75f) {
			material.color = color;
		} else if (1.25f < startTime && startTime <= 1.5f) {
			material.color = Color.red;
		} else if (1.0f < startTime && startTime <= 1.25f) {
			material.color = color;
		} else if (0.75f < startTime && startTime <= 1.0f) {
			material.color = Color.red;
		} else if (0.5f < startTime && startTime <= 0.75f) {
			material.color = color;
		} else if (0.25f < startTime && startTime <= 0.5f) {
			material.color = Color.red;
		} else if (0f < startTime && startTime <= 0.25f) {
			material.color = color;
		}*/
	}
}

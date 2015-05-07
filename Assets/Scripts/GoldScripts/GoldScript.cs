using UnityEngine;
using System.Collections;

public class GoldScript : MonoBehaviour {

	//The life time of the gold
	private float lifeTime = 5.0f;
	private float startTime = 0.0f;
	Material material;
	Color color;

	void Start () {
		// set startTime as lifeTime
		startTime = Time.time + lifeTime;
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
	}
	
	void Update () {
		if(startTime <= Time.time){
			Destroy(gameObject);
		} else if (startTime - 3f < Time.time && Time.time <= startTime - 2.75f) {
			material.color = Color.clear;
		} else if (startTime - 2.75f < Time.time && Time.time <= startTime - 2.5f) {
			material.color = color;
		} else if (startTime - 2.5f < Time.time && Time.time <= startTime - 2.25f) {
			material.color = Color.clear;
		} else if (startTime - 2.25f < Time.time && Time.time <= startTime - 2f) {
			material.color = color;
		} else if (startTime - 2f < Time.time && Time.time <= startTime - 1.75f) {
			material.color = Color.clear;
		} else if (startTime - 1.75f < Time.time && Time.time <= startTime - 1.5f) {
			material.color = color;
		} else if (startTime - 1.5f < Time.time && Time.time <= startTime - 1.25f) {
			material.color = Color.clear;
		} else if (startTime - 1.25f < Time.time && Time.time <= startTime - 1f) {
			material.color = color;
		} else if(startTime - 1f < Time.time && Time.time <= startTime - 0.75f) {
			material.color = Color.clear;
		} else if(startTime - 0.75f < Time.time && Time.time <= startTime - 0.5f) {
			material.color = color;
		} else if(startTime - 0.5f < Time.time && Time.time <= startTime - 0.25f) {
			material.color = Color.clear;
		} else if(startTime - 0.25f < Time.time && Time.time < startTime - 0f) {
			material.color = color;
		}
	}
}

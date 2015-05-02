using UnityEngine;
using System.Collections;

public class GoldScript : MonoBehaviour {

	//The life time of the gold
	private float lifeTime = 5.0f;
	private float startTime = 0.0f;

	void Start () {
		//set startTime as lifeTime
		startTime = Time.time + lifeTime;
	}
	
	void Update () {

		//Destroy object when a startTime has passed.
		if(startTime <= Time.time){
			Destroy(gameObject);
		}
	}
}

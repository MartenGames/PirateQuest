using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JellyFishDamageScript : MonoBehaviour {

	public AudioClip hitPlayer;
	float blinkTime;
	Material material;
	Color color;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
			blinkTime = 0.25f;
			material.color = Color.yellow;
		}
	}
	

	// Use this for initialization
	void Start () {
		material = GetComponent<SpriteRenderer> ().material;
		color = material.color;
		blinkTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		blinkTime -= Time.deltaTime;
		
		if (blinkTime <= 0f) {
			material.color = color;
		} else {
			material.color = Color.yellow;
		}
	}
}

using UnityEngine;
using System.Collections;

public class BarrellExplosionScript : MonoBehaviour {

	public GameObject explosion;
	public AudioClip explosionSound;

	public Canvas defeatCanvas;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log("HOTHOT");
			Destroy(other.gameObject);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			GameObject ex = (GameObject) Instantiate(explosion);
			ex.transform.position = transform.position;
			Destroy(transform.gameObject);

			Die();
		} 
	}

	void Die() {
		GameObject go = GameObject.Find ("EmptyObject(Clone)");
		go.GetComponent<StoringVarScript> ().currentLevelGoldAmount = 0;
		go.GetComponent<StoringVarScript> ().numberOfDeaths += 1;
		defeatCanvas.gameObject.SetActive (true);
	}

	void Start () {
		defeatCanvas = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Canvas> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

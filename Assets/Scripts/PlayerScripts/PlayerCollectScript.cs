using UnityEngine;
using System.Collections;

public class PlayerCollectScript : MonoBehaviour {

	public AudioClip coinCollect;
	public AudioClip foodCollect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.name == "Gold" || other.gameObject.name == "Gold(Clone)") {
			int goldAmount = other.gameObject.GetComponent<GoldScript> ().goldAmount;
			GameObject emptyObject = GameObject.Find ("EmptyObject(Clone)");
			emptyObject.GetComponent<StoringVarScript> ().currentLevelGoldAmount += goldAmount;
			//GoldAmountManagerScript.goldAmount += goldValue;
			AudioSource.PlayClipAtPoint (coinCollect, transform.position);
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Food") {
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint (foodCollect, transform.position);
		}
	}
}

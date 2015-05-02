using UnityEngine;
using System.Collections;

public class PlayerCollectScript : MonoBehaviour {

	public int goldValue = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.name == "Gold" || other.gameObject.name == "Gold(Clone)") {
			GoldAmountManagerScript.goldAmount += goldValue;
			Destroy(other.gameObject);
		}
	}
}

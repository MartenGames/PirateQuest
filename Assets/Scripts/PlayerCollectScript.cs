using UnityEngine;
using System.Collections;

public class PlayerCollectScript : MonoBehaviour {

	public int goldValue = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.name == "Gold") {
			GoldAmountManagerScript.goldAmount += goldValue;
			Destroy(other.gameObject);
		}
	}
}

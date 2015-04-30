using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float moveSpeed;

	void Start () {
		
	}

	void FixedUpdate () {

		if (Input.GetKey(KeyCode.DownArrow)) {
			
			//Move down. If the ship is at the edge of the map it stops.

			transform.Translate(new Vector3(0, moveSpeed, 0));
			
			
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			
			//Move up. If the ship is at the edge of the map it stops.

			transform.Translate(new Vector3(0, -moveSpeed, 0));
			
		}

		//Rotate the ship to the left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(new Vector3(0, 0, moveSpeed * 20));
			
		}
		
		//Rotate the ship to the right
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(0, 0, -moveSpeed * 20);
		}
	}
}

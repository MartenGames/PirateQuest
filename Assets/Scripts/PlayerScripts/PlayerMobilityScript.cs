using UnityEngine;
using System.Collections;

public class PlayerMobilityScript : MonoBehaviour {


	public float moveSpeed;	   //The current speed of the ship
	public float rotateSpeed;  //How fast the ship rotates
	public float MaxSpeed;     //This is the maximum speed that the ship will achieve 
	public float Acceleration; //How fast will object reach a maximum speed
	bool keyPressed;		   //boolean value that checks if the user is pressing the up or down arrow

	void Start() {
		MaxSpeed += GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().speed;
		Acceleration += GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().acceleration;
		rotateSpeed += GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().rotateSpeed;
	}
	
	void Update () {

		//The player isn't holding any key 
		keyPressed = false;

		if (GameObject.Find ("EmptyObject(Clone)").GetComponent<StoringVarScript> ().isPaused == false) {
			//Move the ship forward
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {

				keyPressed = true;

				//If the ship is in a backward motion we quickly change that
				if (moveSpeed < 0) {
					moveSpeed += Acceleration * 2 * Time.deltaTime;
				}

				//Increase the speed gradually with respect to the acceleration
				moveSpeed += Acceleration * Time.deltaTime;

				//Actual moving of the ship
				transform.Translate (new Vector3 (0, -moveSpeed, 0));

			}

			//Move the ship backwards
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {

				keyPressed = true;

				//If the ship is in a forward motion we quickly change that
				if (moveSpeed > 0) {
					moveSpeed -= Acceleration * 2 * Time.deltaTime;
				}

				//Increase the speed gradually with respect to the acceleration
				moveSpeed -= Acceleration * Time.deltaTime;

				//Actual moving of the ship
				transform.Translate (new Vector3 (0, -moveSpeed, 0));

			}
			//Rotate the ship to the left
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {

				transform.Rotate (new Vector3 (0, 0, rotateSpeed));
				
			}
			
			//Rotate the ship to the right
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {

				transform.Rotate (0, 0, -rotateSpeed);
			} 

			//Make sure that the ship doesn't go too fast forward or backwards
			if (moveSpeed > MaxSpeed) {
				moveSpeed = MaxSpeed;
			}

			if (moveSpeed < -MaxSpeed) {
				moveSpeed = -MaxSpeed;
			}


			//If the user isn't pressing the up and down arrow we decrese the movement of the ship to 0
			if (!keyPressed) {

				if (moveSpeed > 0) {
					moveSpeed -= Acceleration * Time.deltaTime;
				} else if (moveSpeed < 0) {
					moveSpeed += Acceleration * Time.deltaTime;
				}
				transform.Translate (new Vector3 (0, -moveSpeed, 0));


			}
		} 
	} 
}

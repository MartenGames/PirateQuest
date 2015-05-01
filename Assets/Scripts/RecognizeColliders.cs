using UnityEngine;
using System.Collections;

public class RecognizeColliders : MonoBehaviour
{
	public float moveSpeed = 8.0f; 
	public float rotationSpeed = 2.0f; 
	
	public float minDist = 4.0f; 
	public float maxDist = 45.0f;
	
	private float minSqrDist; 
	private float maxSqrDist;
	
	private Transform myTransform;
	private Transform target;
	
	private Rigidbody2D myRigidbody;
	private Vector3 desiredVelocity;
	
	
	void Start() 
	{
		minSqrDist = minDist * minDist;
		maxSqrDist = maxDist * maxDist;
		
		myTransform = transform;
		myRigidbody = GetComponent<Rigidbody2D>();
		
		GameObject go = GameObject.Find("Player");
		target = go.transform;
		
		// moveSpeed += Random.value * someMultiplier; // add randomness to each enemy moveSpeed, same can be done for rotationSpeed
	}
	
	void Update() 
	{
		float sqrDist = ( target.position - myTransform.position ).sqrMagnitude;
		
		Quaternion calcRot = Quaternion.LookRotation( target.position - myTransform.position );
		
		desiredVelocity = new Vector3( 0, myRigidbody.velocity.y, 0 );
		
		// apply rotation
		myTransform.rotation = Quaternion.Slerp( myTransform.rotation, calcRot, rotationSpeed * Time.deltaTime );
		
		// modify desiredVelocity if within range
		if ( sqrDist > minSqrDist && sqrDist < maxSqrDist )
		{
			desiredVelocity = myTransform.forward * moveSpeed;
			desiredVelocity.y = myRigidbody.velocity.y;
		}
	}
	
	void FixedUpdate() 
	{
		myRigidbody.velocity = desiredVelocity;
	}
}

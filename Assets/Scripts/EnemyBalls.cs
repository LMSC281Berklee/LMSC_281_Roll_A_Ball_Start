//Kristian Veech
//October 21st, 2016

using UnityEngine;
using System.Collections;

public class EnemyBalls : MonoBehaviour {

	private float speed = 100.0f;
	public Rigidbody rb;

	//JC from MoveTowardObject.cs
	//if we know we will only need to target the same object for the entire application, we can use the 
	//drag and drop functionality in the inspector window with a public variable
	public Transform target;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();


	}

	void FixedUpdate () {

		//JC from MoveTowardObject.cs

		//		float step = speed * Time.deltaTime;
		//		transform.position = Vector3.MoveTowards(transform.position, target.position, step);


		//JC if you did want to use the AddForce function you could look in the Scripting API and find this:
		//https://docs.unity3d.com/ScriptReference/Rigidbody.AddForceAtPosition.html

		//JC but rather than using the target player as the area to push the enemy away from we need to push the enemy "TO" the target
		Vector3 direction = rb.transform.position - target.transform.position;
		rb.AddForceAtPosition((-direction.normalized), target.transform.position);

		//	rb.AddForce(0,0, speed, ForceMode.Impulse);


	}

	//void OnTriggerEnter (Collider other){


		//rb.AddForce(1,1, speed, ForceMode.Impulse);
	//}
}
/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	private Rigidbody objectRigidbody;
	public float push;
	private int count;
	public Text countText;
	public Text winText;
	//new private Rigidbody variable **spieldenner
	private Rigidbody rb;
	//public float value for jump height **spieldenner
	public float jump;

	// Use this for initialization
	void Start () {
		objectRigidbody = GetComponent<Rigidbody>();
		count = 0;
		SetCounter();
		//define variable **spieldenner
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		objectRigidbody.AddForce(movement*push);
		//when the space bar is pressed, ball jumps **spieldenner
		if (Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
		}
	}

	void OnTriggerEnter (Collider collObject) {
		if (collObject.gameObject.CompareTag("PickUp")) {
			collObject.gameObject.SetActive(false);
			count++;
			SetCounter();
		}
	}

	void SetCounter() {
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			winText.text = "You've Won the Game!!!";
		}
	}


}

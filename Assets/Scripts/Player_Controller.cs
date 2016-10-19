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

	// Use this for initialization
	void Start () {
		objectRigidbody = GetComponent<Rigidbody>();
		count = 0;
		SetCounter();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		objectRigidbody.AddForce(movement*push);

		//make player jump when space bar is pressed (Source: http://answers.unity3d.com/questions/190837/make-a-rigidbody-jump-global-up.html)
		if (Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
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

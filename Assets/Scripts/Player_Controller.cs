/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */
//Antonio Espinosa Holguín (Antonio Espinosa branch)
//October 20th, 2016
//This script has been altered so that it functions as the "level 1" script.
//To that end the "you've won!" behaviour has been changed to a LoadScene function.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
<<<<<<< HEAD

		//make player jump when space bar is pressed (Source: http://answers.unity3d.com/questions/190837/make-a-rigidbody-jump-global-up.html)
		if (Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
=======
		//when the space bar is pressed, ball jumps **spieldenner
		if (Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
>>>>>>> master
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
<<<<<<< HEAD
		if (count >= 9) {
			winText.text = "You've Won the Game!!!";
=======
		if (count >= 12) {
			SceneManager.LoadScene ("Level2");
>>>>>>> master
		}
	}


}

﻿//Modified by Alexander J. Harder
/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 *from LMSC-281 Roll-a-Ball modified project
 */

//Antonio Espinosa Holguín (Antonio Espinosa branch)
//October 20th, 2016
//This script has been altered so that it functions as the "level 1" script.
//To that end the "you've won!" behaviour has been changed to a LoadScene function.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//to include the new scene load function
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

	private Rigidbody objectRigidbody;
	private int count;

	//JC The following allows for individual levels to set varying numbers of pickups needed to win
	public int countToWin = 12;

	//SRamos audio functionality
	private AudioSource source;

	//making push public allows each scene to set a different amount
	public float push;	

	public Text countText;
	public Text winText;
	public AudioClip mariocoin;

	//float for the timer bCor
	float timeRemaining = 30;

	//from JCox
	private float levelDelay = 3.0f;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		objectRigidbody = GetComponent<Rigidbody>();
		count = 0;
		SetCounter();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//creates countdown bCor
		timeRemaining -= Time.deltaTime;

		//jump function using force
		if (Input.GetKeyDown ("space")){

			objectRigidbody.AddForce (0, 300, 0);
		}

		objectRigidbody.AddForce(movement*push);

        //to jump
        //based on code from http://answers.unity3d.com/questions/190837/make-a-rigidbody-jump-global-up.html
        //and http://answers.unity3d.com/questions/30127/how-can-i-make-my-character-jump.html
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime, Space.World);
        }
    }

	void OnTriggerEnter (Collider collObject) {
		if (collObject.gameObject.CompareTag("PickUp")) {
			collObject.gameObject.SetActive(false);
			count++;
			SetCounter();
			source.PlayOneShot(mariocoin, 1.0f);

		}
	}

	void SetCounter() {
		countText.text = "Count: " + count.ToString();
		if (count >= countToWin) {
			winText.text = "You've Won the Game!!!";
			Invoke ("NextLevel", levelDelay);
			//stops countdown bCor
			timeRemaining = 30;
		}
	}
		
	void NextLevel () {

//		if (SceneManager.GetActiveScene().name == "Mini_Game") {
//			SceneManager.LoadScene ("Level1"); 
//		}
//		else if (SceneManager.GetActiveScene().name == "Level1") {
//			SceneManager.LoadScene ("Level2"); 
//		}
//		else if (SceneManager.GetActiveScene().name == "Level2") {
//			SceneManager.LoadScene ("Level3"); 
//		}
//		else if (SceneManager.GetActiveScene().name == "Level3") {
//			SceneManager.LoadScene ("Mini_Game_Destructor"); 
//		}
	

	//Given that we have quite a few if-then-else statements we should convert the above code into a case/switch statement

		switch (SceneManager.GetActiveScene().name)
		{
		case ("Mini_Game"):
			SceneManager.LoadScene ("Level1");
			break;
		case ("Level1"):
			SceneManager.LoadScene ("Level2"); 
			break;
		case ("Level2"):
			SceneManager.LoadScene ("Level3");
			break;
		case ("Level3"):
			SceneManager.LoadScene ("Mini_Game_Destructor");
			break;
		default:
			SceneManager.LoadScene ("Mini_Game");
			break;
		}
	}
	//creates timer on screen bCor and restart button with the switch statement

	void OnGUI(){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (450, 10, 200, 300), "Time Remaining : " + (int)timeRemaining);


		} else {
			if (GUI.Button (new Rect (100, 10, 150, 100), "Restart Level"))
				switch (SceneManager.GetActiveScene ().name) {
				case ("Mini_Game"):
					SceneManager.LoadScene ("Mini_Game");
					break;
				case ("Level1"):
					SceneManager.LoadScene ("Level1"); 
					break;
				case ("Level2"):
					SceneManager.LoadScene ("Level2");
					break;
				case ("Level3"):
					SceneManager.LoadScene ("Level3");
					break;
				default:
					SceneManager.LoadScene ("Mini_Game");
					break;
				}
			}

	}
		
}


//This section is an extra jump function but instead of "jump" it became "teleport up in space then fall"
	//void Update () {
	//	        if (Input.GetKeyDown ("space")){
	//		                 transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
	//	} 
	//}
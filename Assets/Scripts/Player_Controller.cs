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

	public float push;	
	public Text countText;
	public Text winText;
	public AudioClip mariocoin;

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

		//jump function using force
		if (Input.GetKeyDown ("space")){

			objectRigidbody.AddForce (0, 300, 0);
		}

		objectRigidbody.AddForce(movement*push);
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
		}
	}
		
	void NextLevel () {

		if (Application.loadedLevelName == "Mini_Game") {
			SceneManager.LoadScene ("Level1"); 
		}
		else if (Application.loadedLevelName == "Level1") {
			SceneManager.LoadScene ("Level2"); 
		}
		else if (Application.loadedLevelName == "Level2") {
			SceneManager.LoadScene ("Level3"); 
		}
		else if (Application.loadedLevelName == "Level3") {
			SceneManager.LoadScene ("Mini_Game_Destructor"); 
		}
	}
}

//This section is an extra jump function but instead of "jump" it became "teleport up in space then fall"
	//void Update () {
	//	        if (Input.GetKeyDown ("space")){
	//		                 transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
	//	} 
	//}


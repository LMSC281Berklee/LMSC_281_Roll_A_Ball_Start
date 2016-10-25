//LMSC-281 Logic and Programming
//Unity Rollerball Tutorial
//from http://www.unity3D.com
//with introductory UserPrefs and additional audio examples
//by Jeanine Cowen - Fall 2016

using UnityEngine;
using System.Collections;

public class PlayerController_w_LeaderBoard : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;
	public int count;

	//for the highscore leaderboard
	public int highScore = 0;
	string highScoreKey = "HighScore";

	//or you can keep a number of highscores in an array
	int[] highScores = new int[5];


	
	void Start () {
		count = 0;
		SetCountText ();
		winText.text = "";

		//Get the highScore from player prefs if it is there, 0 otherwise.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);    
	}

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			GetComponent<AudioSource>().Play();
		}
	}

	void OnCollisionEnter (Collision other) {
		//JC check to see if there is an audiosource on the object we collided with
		//and if so, play that sound
		if (other.gameObject.GetComponent<AudioSource>() != null) {
			other.gameObject.GetComponent<AudioSource>().Play();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 4) {
			winText.text = "YOU WIN!!!";

			/* this is for a single high score
			if(count>highScore){
				PlayerPrefs.SetInt(highScoreKey, count);
				PlayerPrefs.Save();
			}
			*/

			//use this for a leaderboard style where you save several highscores
			for (int i = 0; i<highScores.Length; i++){
				
				//Get the highScore from 1 - 5
				highScoreKey = "HighScore"+(i+1).ToString();
				highScore = PlayerPrefs.GetInt(highScoreKey,0);
				
				//if score is greater, store previous highScore
				//Set new highScore
				//set score to previous highScore, and try again
				//Once score is greater, it will always be for the
				//remaining list, so the top 5 will always be 
				//updated
				if(count>highScore){
					int temp = highScore;
					PlayerPrefs.SetInt(highScoreKey,count);
					count = temp;
				}
			}
		}
	}
}
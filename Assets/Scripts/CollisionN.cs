//LMSC-281 Fall 2016
//Roll-a-Ball modified project
//from merge with Jessie Cox

using UnityEngine;
using System.Collections;

//to change the loadlevel deprecated command to the new scene load function
using UnityEngine.SceneManagement;



public class CollisionN : MonoBehaviour {
	//private Rigidbody rb;

	public GameObject floor; 

	public GameObject GameOver;

	private float resetDelay = 6f;
	// Use this for initialization
	void Awake () {
		//rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision col)
	{
		Destroy(floor);
		GameOver.SetActive(true);
		Invoke ("Reset", resetDelay);
	}

	void Reset()
	{
		SceneManager.LoadScene ("Mini_Game_Destructor"); 

		//the application loadlevel function is deprecated and should be replaced
//		Application.LoadLevel(Application.loadedLevel);
	}

}



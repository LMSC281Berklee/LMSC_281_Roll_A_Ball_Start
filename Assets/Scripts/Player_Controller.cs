//Modified by Alexander J. Harder
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
		}
	}

	void SetCounter() {
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			SceneManager.LoadScene ("Level2");
		}
	}


}

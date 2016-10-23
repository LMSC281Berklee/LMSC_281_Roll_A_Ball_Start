/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Player_Controller : MonoBehaviour {

	private Rigidbody objectRigidbody;
	private int count;
	private AudioSource source;

	public float push;	
	public Text countText;
	public Text winText;
	public AudioClip mariocoin;



	void Start () {
		source = GetComponent<AudioSource>();
		objectRigidbody = GetComponent<Rigidbody>();
		count = 0;
		SetCounter();

		//source.PlayOneShot(source, 1.0f);
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
		if (count >= 12) {
			winText.text = "You've Won the Game!!!";
		}
	}

//This section is an extra jump function but instead of "jump" it became "teleport up in space then fall"
	//void Update () {
	//	        if (Input.GetKeyDown ("space")){
	//		                 transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
	//	} 
	//}


}
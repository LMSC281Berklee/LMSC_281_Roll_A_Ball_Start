using UnityEngine;
using System.Collections;



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
		
		Application.LoadLevel(Application.loadedLevel);
	}

}



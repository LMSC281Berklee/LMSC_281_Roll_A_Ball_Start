﻿/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */

using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
		cameraOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + cameraOffset;
	}
}

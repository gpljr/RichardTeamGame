﻿using UnityEngine;
using System.Collections;

public class PushTriggerLeft : MonoBehaviour {

	public GameObject pusher;
	private bool pushOn = false;
	private float startLocation;
	public float endLocation = 10f;
	
	
	// Use this for initialization
	void Start () {
		startLocation = pusher.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (pushOn) {
			//pusher.transform.position += new Vector3(0,0.1f,0);
			pusher.GetComponent<Rigidbody2D>().velocity = new Vector2 (-3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (pushOn && pusher.transform.position.x < endLocation) {
			pusher.transform.position = new Vector3 (endLocation,pusher.transform.position.y, pusher.transform.position.z);
		}

		if (!pushOn && pusher.transform.position.x < startLocation) {
			pusher.GetComponent<Rigidbody2D>().velocity = new Vector2 (3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (!pushOn && pusher.transform.position.x > startLocation) {
			pusher.transform.position = new Vector3 (startLocation,pusher.transform.position.y, pusher.transform.position.z);
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player1") {
			pushOn = true;
			
		} else if (other.gameObject.tag == "Player2") {
			pushOn = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player1") {
			pushOn = false;
			
		} else if (other.gameObject.tag == "Player2") {
			pushOn = false;
		}
	}
}

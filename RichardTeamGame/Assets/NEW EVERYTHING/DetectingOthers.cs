using UnityEngine;
using System.Collections;

public class DetectingOthers : MonoBehaviour {

	public static bool disableDown = false;
	public static bool disableUp = false;
	public static bool disableLeft = false;
	public static bool disableRight = false;
	public static bool moving = false;
	public LayerMask WhatIsCollidable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//checking environment
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.5f, WhatIsCollidable);
		Debug.DrawRay(transform.position, -Vector2.up, Color.green);
		if (hit.collider != null) {
			if(hit.collider.tag == "NewBorder"){
				disableDown = true;
			}
			if(hit.collider.tag == "PlayerG" && DetectingOthers2.disableDown2){
				disableDown = true;
			}
			else if(hit.collider.tag == "PlayerG" && Input.GetKeyDown(KeyCode.S) && DetectingOthers2.moving2){
				disableDown = true;
			}
			else if(hit.collider.tag == "PlayerG" && Input.GetKeyDown(KeyCode.S) && !DetectingOthers2.moving2){
				disableDown = false;
				hit.transform.position += new Vector3(0f,-2.32f,0f);
			}

		}

		else if (hit.collider == null) {
			disableDown = false;
		}
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.up, 1.5f, WhatIsCollidable);
		Debug.DrawRay(transform.position, Vector2.up, Color.green);
		if (hit1.collider != null) {
			if(hit1.collider.tag == "NewBorder"){
				disableUp = true;
			}
			if(hit1.collider.tag == "PlayerG" && DetectingOthers2.disableUp2){
				disableUp = true;
			}
			else if(hit1.collider.tag == "PlayerG" && Input.GetKeyDown(KeyCode.W) && DetectingOthers2.moving2){
				disableUp = true;
			}
			else if(hit1.collider.tag == "PlayerG" && Input.GetKeyDown(KeyCode.W) && !DetectingOthers2.moving2){
				disableUp = false;
				hit1.transform.position += new Vector3(0f,2.32f,0f);
			}
		}
		else if (hit1.collider == null) {
			disableUp = false;
		}
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, WhatIsCollidable);
		Debug.DrawRay(transform.position, Vector2.right, Color.green);
		if (hit2.collider != null) {
			if(hit2.collider.tag == "NewBorder"){
				disableRight = true;
			}
		}
		else if (hit2.collider == null) {
			disableRight= false;
		}
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, -Vector2.right, 1.5f, WhatIsCollidable);
		Debug.DrawRay(transform.position, -Vector2.right, Color.green);
		if (hit3.collider != null) {
			if(hit3.collider.tag == "NewBorder"){
				disableLeft = true;
			}
		}
		else if (hit3.collider == null) {
			disableLeft = false;
		}
		//end checking the envrinoment

		//moving the square
		if(!moving){
			if (Input.GetKeyDown (KeyCode.W) && !disableUp) {
				transform.position += new Vector3(0f,2.32f,0f);
			}
			if (Input.GetKeyDown (KeyCode.S) && !disableDown) {
				transform.position += new Vector3(0f,-2.32f,0f);
			}
		}
		//end moving the square
	}
}

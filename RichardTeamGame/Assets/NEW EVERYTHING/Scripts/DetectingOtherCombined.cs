using UnityEngine;
using System.Collections;

public class DetectingOtherCombined : MonoBehaviour {

	private bool disableDown;
	private bool disableUp;
	private bool disableRight;
	private bool disableLeft;
	public static bool movingCombined = false;
	public LayerMask WhatIsCollidable;
	private float move = 2.32f;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {

		
		//checking environment
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.25f, WhatIsCollidable);
		Debug.DrawRay(transform.position, -Vector2.up, Color.green);
		if (hit.collider != null) {
			if(hit.collider.tag == "NewBorder"){
				disableDown = true;
			}
			
		}
		
		else if (hit.collider == null) {
			disableDown = false;
		}
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.up, 1.25f, WhatIsCollidable);
		Debug.DrawRay(transform.position, Vector2.up, Color.green);
		if (hit1.collider != null) {
			if(hit1.collider.tag == "NewBorder"){
				disableUp = true;
			}
		}
		else if (hit1.collider == null) {
			disableUp = false;
		}
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, 1.25f, WhatIsCollidable);
		Debug.DrawRay(transform.position, Vector2.right, Color.green);
		if (hit2.collider != null) {
			if(hit2.collider.tag == "NewBorder"){
				disableRight = true;
			}
		}
		else if (hit2.collider == null) {
			disableRight= false;
		}
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, -Vector2.right, 1.25f, WhatIsCollidable);
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
		if(!movingCombined){
			if (Input.GetKeyDown (KeyCode.W) && !disableUp) {
				transform.position += new Vector3(0f,move,0f);
			}
			if (Input.GetKeyDown (KeyCode.S) && !disableDown) {
				transform.position += new Vector3(0f,-move,0f);
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow) && !disableLeft){
				transform.position += new Vector3(-move, 0f, 0f);
			}
			if (Input.GetKeyDown (KeyCode.RightArrow) && !disableRight){
				transform.position += new Vector3(move,0f,0f);
			}
		}
		//end moving the square
	}
}
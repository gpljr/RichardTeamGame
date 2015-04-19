using UnityEngine;
using System.Collections;

public class DetectingOthers2 : MonoBehaviour {

	public static bool disableDown2 = false;
	public static bool disableUp2 = false;
	public static bool disableLeft2 = false;
	public static bool disableRight2 = false;
	public static bool moving2 = false;
	public LayerMask WhatIsCollidable2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//checking environment
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.5f, WhatIsCollidable2);
		Debug.DrawRay(transform.position, -Vector2.up, Color.green);
		if (hit.collider != null) {
			if(hit.collider.tag == "NewBorder"){
				disableDown2= true;
			}
		}
		else if (hit.collider == null) {
			disableDown2 = false;
		}
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.up, 1.5f, WhatIsCollidable2);
		Debug.DrawRay(transform.position, Vector2.up, Color.green);
		if (hit1.collider != null) {
			if(hit1.collider.tag == "NewBorder"){
				disableUp2 = true;
			}
		}
		else if (hit1.collider == null) {
			disableUp2 = false;
		}
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, WhatIsCollidable2);
		Debug.DrawRay(transform.position, Vector2.right, Color.green);
		if (hit2.collider != null) {
			if(hit2.collider.tag == "NewBorder"){
				disableRight2 = true;
			}
			if(hit2.collider.tag == "PlayerY" && DetectingOthers.disableRight){
				disableRight2 = true;
			}
			else if(hit2.collider.tag == "PlayerY" && Input.GetKeyDown(KeyCode.RightArrow) && DetectingOthers.moving){
				disableRight2 = true;
			}
			else if(hit2.collider.tag == "PlayerY" && Input.GetKeyDown(KeyCode.RightArrow) && !DetectingOthers.moving){
				disableRight2 = false;
				hit2.transform.position += new Vector3(2.32f,0f, 0f);
			}
		}
		else if (hit2.collider == null) {
			disableRight2 = false;
		}
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, -Vector2.right, 1.5f, WhatIsCollidable2);
		Debug.DrawRay(transform.position, -Vector2.right, Color.green);
		if (hit3.collider != null) {
			if(hit3.collider.tag == "NewBorder"){
				disableLeft2 = true;
			}
			if(hit3.collider.tag == "PlayerY" && DetectingOthers.disableLeft){
				disableLeft2 = true;
			}
			else if(hit3.collider.tag == "PlayerY" && Input.GetKeyDown(KeyCode.LeftArrow) && DetectingOthers.moving){
				disableLeft2 = true;
			}
			else if(hit3.collider.tag == "PlayerY" && Input.GetKeyDown(KeyCode.LeftArrow) && !DetectingOthers.moving){
				disableLeft2 = false;
				hit3.transform.position += new Vector3(-2.32f,0f, 0f);
			}
		}
		else if (hit3.collider == null) {
			disableLeft2 = false;
		}
		//end checking the envrinoment
		
		//moving the square
		if(!moving2){
			if (Input.GetKeyDown (KeyCode.LeftArrow) && !disableLeft2) {
				transform.position += new Vector3(-2.32f,0f, 0f);
			}
			if (Input.GetKeyDown (KeyCode.RightArrow) && !disableRight2) {
				transform.position += new Vector3(2.32f,0f, 0f);
			}
		}
		//end moving the square
	}
}

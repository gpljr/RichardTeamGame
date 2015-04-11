using UnityEngine;
using System.Collections;

public class Checker2 : MonoBehaviour {

	public static float tempx2;
	public static float tempy2;
	public static float tempz2;
	public static bool pushed2 = false;
	public static bool border2 = false;
	private float move = 3.2f;
	private bool left = false;
	private bool right = false;


	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			//tempx2 = transform.position.x;
			//tempy2 = transform.position.y;
			//tempz2 = transform.position.z;
			left = true;
			right = false;
			border2 = false;
			pushed2 = false;
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			//tempx2 = transform.position.x;
			//tempy2 = transform.position.y;
			//tempz2 = transform.position.z;
			right = true;
			left = false;
			border2 = false;
			pushed2 = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player1" && Movement.go1 && Movement2.go2) {
			transform.position = new Vector3(tempx2,tempy2,tempz2);
		}
		else if (other.gameObject.tag == "Border" && pushed2) {
			border2 = true;
			transform.position = new Vector3(tempx2,tempy2,tempz2);
		}
		else if (other.gameObject.tag == "Border") {
			transform.position = new Vector3(tempx2,tempy2,tempz2);
		}
		else if (other.gameObject.tag == "Player1" && !Movement.go1){
			if(right){
				Checker1.tempx1 = other.transform.position.x;
				Checker1.tempy1 = other.transform.position.y;
				Checker1.tempz1 = other.transform.position.z;
				Checker1.pushed1 = true;
				other.transform.position += new Vector3(move,0,0);
				if(Checker1.border1){
					transform.position = new Vector3(tempx2,tempy2,tempz2);
				}
			}
			if(left){
				Checker1.tempx1 = other.transform.position.x;
				Checker1.tempy1 = other.transform.position.y;
				Checker1.tempz1 = other.transform.position.z;
				Checker1.pushed1 = true;
				other.transform.position += new Vector3(-move,0,0);
				if(Checker1.border1){
					transform.position = new Vector3(tempx2,tempy2,tempz2);
				}
			}
		}
		if (other.gameObject.tag == "PusherEDGE") {
			this.transform.position = new Vector3(tempx2,tempy2,tempz2);
		}
		else if (other.gameObject.tag == "PusherUP") {
			this.transform.position += new Vector3(0,3.2f,0);
				}
		else if (other.gameObject.tag == "PusherDOWN") {
			this.transform.position += new Vector3(0,-3.2f,0);
				}

	}
}
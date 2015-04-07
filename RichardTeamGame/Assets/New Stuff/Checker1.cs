using UnityEngine;
using System.Collections;

public class Checker1 : MonoBehaviour {

	public static float tempx1;
	public static float tempy1;
	public static float tempz1;
	public static bool pushed1 = false;
	public static bool border1 = false;
	private float move = 3.2f;
	private bool up = false;
	private bool down = false;


	void Update () {
	if (Input.GetKeyDown (KeyCode.S)) {
			//tempx1 = transform.position.x;
			//tempy1 = transform.position.y;
			//tempz1 = transform.position.z;
			down = true;
			up = false;
			border1 = false;
			pushed1 = false;
		}

	if (Input.GetKeyDown (KeyCode.W)) {
			//tempx1 = transform.position.x;
			//tempy1 = transform.position.y;
			//tempz1 = transform.position.z;
			up = true;
			down = false;
			border1 = false;
			pushed1 = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player2" && Movement2.go2 && Movement.go1) {
			transform.position = new Vector3(tempx1,tempy1,tempz1);
		}
		else if (other.gameObject.tag == "Border" && pushed1) {
			border1 = true;
			transform.position = new Vector3(tempx1,tempy1,tempz1);
		}
		else if (other.gameObject.tag == "Border") {
			transform.position = new Vector3(tempx1,tempy1,tempz1);
		}
		else if (other.gameObject.tag == "Player2" && !Movement2.go2){
			if(up){
				Checker2.tempx2 = other.transform.position.x;
				Checker2.tempy2 = other.transform.position.y;
				Checker2.tempz2 = other.transform.position.z;
				Checker2.pushed2 = true;
				other.transform.position += new Vector3(0,move,0);
				if(Checker2.border2){
					transform.position = new Vector3(tempx1,tempy1,tempz1);
				}
			}
			if(down){
				Checker2.tempx2 = other.transform.position.x;
				Checker2.tempy2 = other.transform.position.y;
				Checker2.tempz2 = other.transform.position.z;
				Checker2.pushed2 = true;
				other.transform.position += new Vector3(0,-move,0);
				if(Checker2.border2){
					transform.position = new Vector3(tempx1,tempy1,tempz1);
				}
			}
		}
	}
}

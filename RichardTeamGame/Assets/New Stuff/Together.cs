using UnityEngine;
using System.Collections;

public class Together : MonoBehaviour {

	private float tempx;
	private float tempy;
	private float tempz;
	private float move = 3.2f;
	private bool border = false;
	public static bool go = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.W) && !go) {
			tempx = transform.position.x;
			tempy = transform.position.y;
			tempz = transform.position.z;
			transform.position += new Vector3(0, move,0);
			go = true;
		}
		if (Input.GetKeyDown (KeyCode.S) && !go) {
			tempx = transform.position.x;
			tempy = transform.position.y;
			tempz = transform.position.z;
			transform.position += new Vector3(0, -move,0);
			go = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && !go) {
			tempx = transform.position.x;
			tempy = transform.position.y;
			tempz = transform.position.z;
			transform.position += new Vector3(-move,0,0);
			go = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && !go) {
			tempx = transform.position.x;
			tempy = transform.position.y;
			tempz = transform.position.z;
			transform.position += new Vector3(move,0,0);
			go = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Border") {
			transform.position = new Vector3(tempx,tempy,tempz);
		}
	}
}

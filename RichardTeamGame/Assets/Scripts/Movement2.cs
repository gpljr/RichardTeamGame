using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {

	public float maxSpeed2 = 10f;
	public GameObject camera1;
	public GameObject camera2;

	private bool cSwitch = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float move = Input.GetAxis ("Horizontal1");
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed2, rigidbody2D.velocity.y);
		
		float moveV = Input.GetAxis ("Vertical1");
		
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveV * maxSpeed2);
	}

	void Update (){
		if (!cSwitch && Input.GetKeyDown (KeyCode.Space)) {
						camera1.SetActive (false);
						camera2.SetActive (true);
			cSwitch = true;

				} else if (cSwitch && Input.GetKeyDown (KeyCode.Space)) {
			camera1.SetActive (true);
			camera2.SetActive (false);
			cSwitch = false;
				}

	}


}

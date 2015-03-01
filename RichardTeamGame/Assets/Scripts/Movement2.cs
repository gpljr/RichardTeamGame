using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {

	public float maxSpeed2 = 10f;

	public static float player2x = this.Transform.position.x;
	public static float player2y = this.transform.posiiton.y;

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



}

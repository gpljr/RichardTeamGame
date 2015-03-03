using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{


		public float maxSpeed = 10f;
	public static float player1x;
	public static float player1y;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
	
				float move = Input.GetAxis ("Horizontal");

				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

				/*float moveV = Input.GetAxis ("Vertical");

				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveV * maxSpeed);*/

		}

	void Update (){
		player1x = this.transform.position.x;
		player1y = this.transform.position.y;
	}
}

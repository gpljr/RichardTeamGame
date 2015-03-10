using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{


		public float maxSpeed = 10f;
	public static float player1x;
	public static float player1y;
	private bool cheatMode = false;
	public GameObject CheatIndicator;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			if (!cheatMode) {
						float move = Input.GetAxis ("Horizontal");

						rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

						/*float moveV = Input.GetAxis ("Vertical");

				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveV * maxSpeed);*/
				} else if (cheatMode) {
			float move = Input.GetAxis ("Horizontal");
			
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			
			float moveV = Input.GetAxis ("Vertical");

				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, moveV * maxSpeed);
				}

		}

	void Update (){
		if (Input.GetKeyDown (KeyCode.P)) {
			if(!cheatMode){
				cheatMode = true;
				CheatIndicator.SetActive (true);
			}
			else if(cheatMode){
				cheatMode = false;
				CheatIndicator.SetActive (false);
			}
				}
		player1x = this.transform.position.x;
		player1y = this.transform.position.y;
	}
}

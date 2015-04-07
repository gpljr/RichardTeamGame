using UnityEngine;
using System.Collections;

public class OLDMovement2 : MonoBehaviour {

	public float maxSpeed2 = 10f;

	public static float player2x;
	public static float player2y;
	private bool cheatMode = false;
	public GameObject CheatIndicator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	

		if (!cheatMode) {
						/*float move = Input.GetAxis ("Horizontal1");
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed2, rigidbody2D.velocity.y);*/
		
						float moveV = Input.GetAxis ("Vertical1");
		
						GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, moveV * maxSpeed2);
				} else if (cheatMode) {
			float move = Input.GetAxis ("Horizontal1");
		
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed2, GetComponent<Rigidbody2D>().velocity.y);
			
			float moveV = Input.GetAxis ("Vertical1");
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, moveV * maxSpeed2);
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

		player2x = this.transform.position.x;
		player2y = this.transform.position.y;
	}


}

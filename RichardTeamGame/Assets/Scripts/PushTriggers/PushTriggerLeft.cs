using UnityEngine;
using System.Collections;

public class PushTriggerLeft : MonoBehaviour {

	public GameObject pusher;
	private bool pushOn = false;
	private float startLocation;
	
	
	// Use this for initialization
	void Start () {
		startLocation = pusher.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (pushOn) {
			//pusher.transform.position += new Vector3(0,0.1f,0);
			pusher.rigidbody2D.velocity = new Vector2 (-3f, rigidbody2D.velocity.y);
		}
		if (!pushOn && pusher.transform.position.x < startLocation) {
			pusher.rigidbody2D.velocity = new Vector2 (3f, rigidbody2D.velocity.y);
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player1") {
			pushOn = true;
			
		} else if (other.gameObject.tag == "Player2") {
			pushOn = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player1") {
			pushOn = false;
			
		} else if (other.gameObject.tag == "Player2") {
			pushOn = false;
		}
	}
}

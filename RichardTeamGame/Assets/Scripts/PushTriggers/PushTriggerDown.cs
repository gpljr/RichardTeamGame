using UnityEngine;
using System.Collections;

public class PushTriggerDown : MonoBehaviour {
	public GameObject pusher;
	private bool pushOn = false;
	private float startLocation;
	public float endLocation = 10f;
	
	
	// Use this for initialization
	void Start () {
		startLocation = pusher.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (pushOn) {
			//pusher.transform.position += new Vector3(0,0.1f,0);
			pusher.rigidbody2D.velocity = new Vector2 ( rigidbody2D.velocity.x, -3);
		}
		if (pushOn && pusher.transform.position.y < endLocation) {
			pusher.transform.position = new Vector3 (pusher.transform.position.x,endLocation, pusher.transform.position.z);
		}
		if (!pushOn && pusher.transform.position.y < startLocation) {
			pusher.rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 3);
		}

		if (!pushOn && pusher.transform.position.y > startLocation) {
			pusher.transform.position = new Vector3 (pusher.transform.position.x,startLocation, pusher.transform.position.z);
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

using UnityEngine;
using System.Collections;

public class PushTrigger : MonoBehaviour {

	public GameObject pusher;
	private bool pushOn = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pushOn) {
			pusher.transform.position += new Vector3(0.1f,0,0);
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

using UnityEngine;
using System.Collections;

public class AutoPusherUp : MonoBehaviour {

	private float startLocation;
	public float endLocation = 10f;
	private bool change = true;
	
	// Use this for initialization
	void Start () {
		startLocation = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (change && this.transform.position.y < endLocation) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, 3f);
		}
		if (change && this.transform.position.y > endLocation) {
			change = false;
		}
		if (!change && this.transform.position.y > startLocation) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, -3f);
		}
		if (!change && this.transform.position.y < startLocation) {
			change = true;
		}
		
	}
}

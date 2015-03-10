using UnityEngine;
using System.Collections;

public class AutoPusher : MonoBehaviour {

	private float startLocation;
	public float endLocation = 10f;
	private bool change = true;

	// Use this for initialization
	void Start () {
		startLocation = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (change && this.transform.position.x < endLocation) {
			this.rigidbody2D.velocity = new Vector2 (3, rigidbody2D.velocity.y);
		}
		if (change && this.transform.position.x > endLocation) {
			change = false;
		}
		if (!change && this.transform.position.x > startLocation) {
			this.rigidbody2D.velocity = new Vector2 (-3, rigidbody2D.velocity.y);
		}
		if (!change && this.transform.position.x < startLocation) {
			change = true;
		}

	}
}

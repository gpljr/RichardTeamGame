using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	public static bool go1 = false;
	private float move = 3.2f;
	public static float player1x;
	public static float player1y;

	void Update () {

		player1x = this.transform.position.x;
		player1y = this.transform.position.y;

		if (Input.GetKeyDown (KeyCode.W) && !go1 && !Checker1.pushed1){
		//if (Input.GetKey (KeyCode.W) && !go1){
		//if (Input.GetKeyDown (KeyCode.W)) {
			Checker1.tempx1 = target.transform.position.x;
			Checker1.tempy1 = target.transform.position.y;
			Checker1.tempz1 = target.transform.position.z;
			target.transform.position += new Vector3(0, move,0);
			go1 = true;
		}
		if (Input.GetKeyDown (KeyCode.S) && !go1 && !Checker1.pushed1){
		//if (Input.GetKeyDown (KeyCode.S)) {
			Checker1.tempx1 = target.transform.position.x;
			Checker1.tempy1 = target.transform.position.y;
			Checker1.tempz1 = target.transform.position.z;
			target.transform.position += new Vector3(0,-move,0);
			go1 = true;
		}

		if (Checker1.pushed1) {
			Checker1.pushed1 = false;
		}
		if (Mathf.Abs (transform.position.x - target.transform.position.x) > 0.1 || Mathf.Abs (transform.position.y - target.transform.position.y) > 0.1) {
			go1 = true;
		}
		if (Mathf.Abs (transform.position.x - target.transform.position.x) < 0.1 && Mathf.Abs (transform.position.y - target.transform.position.y) < 0.1) {
			go1 = false;
		}

		
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}


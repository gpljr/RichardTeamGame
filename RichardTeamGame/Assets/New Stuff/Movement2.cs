using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	public static bool go2 = false;
	private float move = 3.2f;
	public static float player2x;
	public static float player2y;

	void Update () {

		player2x = this.transform.position.x;
		player2y = this.transform.position.y;

		if (Input.GetKeyDown (KeyCode.LeftArrow) && !go2 && !Checker2.pushed2){
		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Checker2.tempx2 = target.transform.position.x;
			Checker2.tempy2 = target.transform.position.y;
			Checker2.tempz2 = target.transform.position.z;
			target.transform.position += new Vector3(-move,0,0);
			go2 = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && !go2 && !Checker2.pushed2){
		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Checker2.tempx2 = target.transform.position.x;
			Checker2.tempy2 = target.transform.position.y;
			Checker2.tempz2 = target.transform.position.z;
			target.transform.position += new Vector3(move,0,0);
			go2 = true;
		}

		if (Checker2.pushed2) {
			Checker2.pushed2 = false;
		}

		if (Mathf.Abs (transform.position.x - target.transform.position.x) > 0.1 || Mathf.Abs (transform.position.y - target.transform.position.y) > 0.1) {
			go2 = true;
		}

		if (Mathf.Abs (transform.position.x - target.transform.position.x) < 0.1 && Mathf.Abs (transform.position.y - target.transform.position.y) < 0.1) {
			go2 = false;
		}
		
		
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
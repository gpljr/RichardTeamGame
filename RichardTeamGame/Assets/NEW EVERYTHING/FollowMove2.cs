using UnityEngine;
using System.Collections;

public class FollowMove2 : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.1F;
	private Vector3 velocity = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x - target.transform.position.x) > 0.1f || Mathf.Abs (transform.position.y - target.transform.position.y) > 0.1) {
			DetectingOthers2.moving2 = true;
		}
		if (Mathf.Abs (transform.position.x - target.transform.position.x) < 0.1f && Mathf.Abs (transform.position.y - target.transform.position.y) < 0.1f) {
			DetectingOthers2.moving2 = false;
		}
		
		
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
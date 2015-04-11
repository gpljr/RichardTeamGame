using UnityEngine;
using System.Collections;

public class TogetherMovement : MonoBehaviour {


	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x - target.transform.position.x) > 0.1 || Mathf.Abs (transform.position.y - target.transform.position.y) > 0.1) {
			Together.go = true;
		}
		if (Mathf.Abs (transform.position.x - target.transform.position.x) < 0.1f && Mathf.Abs (transform.position.y - target.transform.position.y) < 0.1f) {
			Together.go = false;
		}

		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

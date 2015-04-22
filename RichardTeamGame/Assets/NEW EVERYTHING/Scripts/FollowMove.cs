using UnityEngine;
using System.Collections;

public class FollowMove : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.1F;
	private Vector3 velocity = Vector3.zero;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevelName == "Separation2" || Application.loadedLevelName == "reunion") {
						anim.SetFloat ("Distance", 10f);
				} else {
						anim.SetFloat ("Distance", CameraFollow.boxDistance);
				}

		if (Mathf.Abs (transform.position.x - target.transform.position.x) > 0.1f || Mathf.Abs (transform.position.y - target.transform.position.y) > 0.1) {
			DetectingOthers.moving = true;
		}
		if (Mathf.Abs (transform.position.x - target.transform.position.x) < 0.1f && Mathf.Abs (transform.position.y - target.transform.position.y) < 0.1f) {
			DetectingOthers.moving = false;
		}
		
		
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

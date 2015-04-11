using UnityEngine;
using System.Collections;

public class TogetherFollow : MonoBehaviour {


	public Transform Player;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3(Player.position.x, Player.position.y, -20);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

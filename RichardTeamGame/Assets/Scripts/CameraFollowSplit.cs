using UnityEngine;
using System.Collections;

public class CameraFollowSplit : MonoBehaviour
{

		public float smoothTime = 0.3F;
		private Vector3 velocity = Vector3.zero;
		public Transform Player;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				//this.transform.position = new Vector3 (Player.position.x, Player.position.y, -17f);
				Vector3 targetPosition = new Vector3 (Player.position.x, Player.position.y, -20f);
				transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
		}
}

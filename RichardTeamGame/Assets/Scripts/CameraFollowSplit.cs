using UnityEngine;
using System.Collections;

public class CameraFollowSplit : MonoBehaviour
{
		public Transform Player;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.transform.position = new Vector3 (Player.position.x, Player.position.y, -17f);

		}
}

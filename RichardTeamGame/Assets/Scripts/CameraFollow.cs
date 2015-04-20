using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

		private float p1x;
		private float p1y;
		private float p2x;
		private float p2y;
		private float cameraX = 0;
		private float cameraY = 0;
		public float cameraZ = -20;
		private float boxDistance;
		public Transform Player1;
		public Transform Player2;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKeyDown (KeyCode.Return)) {
						Application.LoadLevel (Application.loadedLevel);
				}

				p1x = Player1.position.x;
				p1y = Player1.position.y;
				p2x = Player2.position.x;
				p2y = Player2.position.y;

				cameraX = (p1x + p2x) / 2;
				cameraY = (p1y + p2y) / 2;

				boxDistance = Vector3.Distance (Player1.position, Player2.position);

				if (boxDistance < 20f) {
						cameraZ = -20;
				} else if (boxDistance > 20f) {
						cameraZ = (-20f - ((boxDistance - 20f)*(2f)));
				}

			//	this.transform.position = new Vector3 (cameraX, cameraY, cameraZ);
		Vector3 targetPosition = new Vector3(cameraX, cameraY, cameraZ);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

		}

}

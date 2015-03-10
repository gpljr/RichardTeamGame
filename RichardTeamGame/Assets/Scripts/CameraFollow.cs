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

				p1x = Movement.player1x;
				p1y = Movement.player1y;
				p2x = Movement2.player2x;
				p2y = Movement2.player2y;

				cameraX = (p1x + p2x) / 2;
				cameraY = (p1y + p2y) / 2;

				boxDistance = Vector3.Distance (Player1.position, Player2.position);

				if (boxDistance < 20f) {
						cameraZ = -20;
				} else if (boxDistance > 20f) {
						cameraZ = (-20f - ((boxDistance - 20f)*(2f)));
				}

				this.transform.position = new Vector3 (cameraX, cameraY, cameraZ);

		}

}

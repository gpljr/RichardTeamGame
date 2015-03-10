using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

		private float timeBetweenShots = 3f;
		public GameObject BulletType;
		public float shotTime = 3f;
		[SerializeField]
		private bool
				canMove;
		[SerializeField]
		private Vector2
				movingVelocity = new Vector2 (1, 0);
		[SerializeField]
		private float
				movingTime = 2f;
		private float timeBetweenMoving = 2f;
		private int moving1 = 1;
		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
				timeBetweenShots -= Time.deltaTime;

				if (timeBetweenShots < 0) {
						Instantiate (BulletType, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
						timeBetweenShots = shotTime;
				}
				if (canMove) {
						timeBetweenMoving -= Time.deltaTime;
						if (timeBetweenMoving < 0) {
								if (moving1 == 1) {
										this.rigidbody2D.velocity = movingVelocity;
								} else if (moving1 == -1) {
										this.rigidbody2D.velocity = -movingVelocity;
								}
								moving1 *= -1;
								timeBetweenMoving = movingTime;
						}
				}


		}
}

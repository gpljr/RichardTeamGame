using UnityEngine;
using System.Collections;

public class FollowMove2 : MonoBehaviour
{
		public Transform target;
		public float smoothTime = 0.1F;
		private Vector3 velocity = Vector3.zero;
		private bool _inStar;
		Animator anim;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
		}
		void OnEnable ()
		{
				Events.g.AddListener<PlayerEnterLevelDoorEvent> (PlayerEnter);
				Events.g.AddListener<PlayerExitLevelDoorEvent> (PlayerExit);
		}
	
		void OnDisable ()
		{
				Events.g.RemoveListener<PlayerEnterLevelDoorEvent> (PlayerEnter);
				Events.g.RemoveListener<PlayerExitLevelDoorEvent> (PlayerExit);
		}
		// Update is called once per frame
		void Update ()
		{

				if (Application.loadedLevelName == "Separation2" || Application.loadedLevelName == "reunion") {
						anim.SetFloat ("Distance2", 10f);
				} else if (_inStar) {
						print ("player2 in star");
						anim.SetFloat ("Distance2", 0f);
				} else {
						anim.SetFloat ("Distance2", CameraFollow.boxDistance);
				}

				if (Mathf.Abs (transform.position.x - target.transform.position.x) > 1f || Mathf.Abs (transform.position.y - target.transform.position.y) > 1f) {
						DetectingOthers2.moving2 = true;
				}
				if (Mathf.Abs (transform.position.x - target.transform.position.x) < 1f && Mathf.Abs (transform.position.y - target.transform.position.y) < 1f) {
						DetectingOthers2.moving2 = false;
				}
		
		
				Vector3 targetPosition = target.TransformPoint (new Vector3 (0, 0, 0));
				transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
		}
		void PlayerEnter (PlayerEnterLevelDoorEvent e)
		{
				if (!e.isPlayerOne) {
						_inStar = true;
				}
		}
		void PlayerExit (PlayerExitLevelDoorEvent e)
		{
				if (!e.isPlayerOne) {
						_inStar = false;
				}
		}
}
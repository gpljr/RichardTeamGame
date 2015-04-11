using UnityEngine;
using System.Collections;

public class TriggerForDoorTemporary : MonoBehaviour
{
		[SerializeField]
		bool
				isStayTrigger;
		[HideInInspector]
		public bool
				isTriggered;
		public AudioClip doorAudio;
		private float volume = 1f;
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") {
						isTriggered = true;
						AudioSource.PlayClipAtPoint (doorAudio, this.transform.position, volume);
				}
		}
		void OnTriggerExit2D (Collider2D other)
		{
				if (other != null && isStayTrigger) {
						isTriggered = false;
				}
		}
}

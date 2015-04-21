using UnityEngine;
using System.Collections;

public class BulletUp : MonoBehaviour
{
		public AudioClip explosionAudio;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				this.transform.position += new Vector3 (0f, 0.1f, 0f);
	
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "PlayerY" || other.gameObject.tag == "PlayerG") {
						AudioSource.PlayClipAtPoint (explosionAudio, this.transform.position);
						CheckPoints.hit = true;
				}
				if (other.gameObject.tag == "BulletDestroyer") {
						Destroy (this.gameObject);
				}
		}

}

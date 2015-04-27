using UnityEngine;
using System.Collections;

public class BgMusic : MonoBehaviour
{
		public AudioClip beginMusic;	
		public AudioClip sadMusic;
		public AudioClip happyMusic;
		public int beginLevel = 1;
		public int sadLevel = 8;
		public int happyLevel = 12;
		// Use this for initialization
		void Start ()
		{
				DontDestroyOnLoad (this);
				

		}
	
		// Update is called once per frame
		void Update ()
		{

				/*if (Application.loadedLevelName == "sadBegin") {
						GameObject.Destroy (this);
						print ("destroy");
				}*/
				//this.transform.position = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
		}
		void OnLevelWasLoaded (int level)
		{
				if (level == beginLevel) {
						gameObject.GetComponent<AudioSource> ().clip = beginMusic;
						gameObject.GetComponent<AudioSource> ().Play ();
						Events.g.Raise (new MusicPlayed (1));
				}
				if (level == sadLevel) {
						while (gameObject.GetComponent<AudioSource> ().volume > 0) {
								gameObject.GetComponent<AudioSource> ().volume -= 0.5f * Time.deltaTime;
						
								if (gameObject.GetComponent<AudioSource> ().volume < 0.1f) {
										gameObject.GetComponent<AudioSource> ().clip = sadMusic;
										gameObject.GetComponent<AudioSource> ().Play ();
										Events.g.Raise (new MusicPlayed (2));
										break;
								}
						}
						while (gameObject.GetComponent<AudioSource> ().volume < 1) {
								gameObject.GetComponent<AudioSource> ().volume += 0.2f * Time.deltaTime;
						}
				} else if (level == happyLevel) {
						while (gameObject.GetComponent<AudioSource> ().volume > 0) {
								gameObject.GetComponent<AudioSource> ().volume -= 0.5f * Time.deltaTime;
				
								if (gameObject.GetComponent<AudioSource> ().volume < 0.1f) {
										gameObject.GetComponent<AudioSource> ().clip = happyMusic;
										gameObject.GetComponent<AudioSource> ().Play ();
										Events.g.Raise (new MusicPlayed (3));
										break;
								}
				
						}
						while (gameObject.GetComponent<AudioSource> ().volume < 1) {
								gameObject.GetComponent<AudioSource> ().volume += 0.2f * Time.deltaTime;
						}
            
				}
		}
}

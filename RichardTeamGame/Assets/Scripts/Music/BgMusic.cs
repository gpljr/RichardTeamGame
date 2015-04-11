using UnityEngine;
using System.Collections;

public class BgMusic : MonoBehaviour
{
		public AudioClip sadMusic;
		public AudioClip happyMusic;
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
				if (level == 9) {
						//gameObject.GetComponent<AudioSource> ().clip = sadMusic;
						//gameObject.GetComponent<AudioSource> ().Play ();
				} else if (level == 13) {
						//gameObject.GetComponent<AudioSource> ().clip = happyMusic;
						//gameObject.GetComponent<AudioSource> ().Play ();
				}
		}
}

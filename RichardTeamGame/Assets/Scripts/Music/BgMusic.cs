using UnityEngine;
using System.Collections;

public class BgMusic : MonoBehaviour
{
    public AudioClip sadMusic;
    public AudioClip happyMusic;
    public int sadLevel = 8;
    public int happyLevel = 12;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
    }
	
    // Update is called once per frame
    void Update()
    {

        /*if (Application.loadedLevelName == "sadBegin") {
						GameObject.Destroy (this);
						print ("destroy");
				}*/
        //this.transform.position = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
    }
    void OnLevelWasLoaded(int level)
    {
        if (level == sadLevel)
        {
            while (gameObject.GetComponent<AudioSource> ().volume > 0)
            {
                gameObject.GetComponent<AudioSource>().volume -= 0.1f * Time.deltaTime;
                print(gameObject.GetComponent<AudioSource>().volume);
						
                if (gameObject.GetComponent<AudioSource>().volume < 0.1f)
                {
                    gameObject.GetComponent<AudioSource>().clip = sadMusic;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                }

            }
            while (gameObject.GetComponent<AudioSource> ().volume < 1)
            {
                gameObject.GetComponent<AudioSource>().volume += 0.1f * Time.deltaTime;
            }
        } else if (level == happyLevel)
        {
            while (gameObject.GetComponent<AudioSource> ().volume > 0)
            {
                gameObject.GetComponent<AudioSource>().volume -= 0.1f * Time.deltaTime;
                print(gameObject.GetComponent<AudioSource>().volume);
				
                if (gameObject.GetComponent<AudioSource>().volume < 0.1f)
                {
                    gameObject.GetComponent<AudioSource>().clip = happyMusic;
                    gameObject.GetComponent<AudioSource>().Play();
                    break;
                }
				
            }
            while (gameObject.GetComponent<AudioSource> ().volume < 1)
            {
                gameObject.GetComponent<AudioSource>().volume += 0.1f * Time.deltaTime;
            }
            
        }
    }
}

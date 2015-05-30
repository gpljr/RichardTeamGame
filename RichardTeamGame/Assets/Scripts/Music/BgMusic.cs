using UnityEngine;
using System.Collections;

public class BgMusic : MonoBehaviour
{
    public static BgMusic instance;
    private int _iCurrentMusicId = 1;
    private int _iMusicId = 1;

    public AudioClip beginMusic;
    public AudioClip sadMusic;
    public AudioClip happyMusic;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        print("instance " + instance);
        if (instance != null)
        {
            Destroy(gameObject);
            print("destroy");
        }
        else
        {
            instance = this;
        }
        
    }

    void OnEnable()
    {			
        Events.g.AddListener<LevelEnteringEvent>(LevelEntered);
    }
	
    void OnDisable()
    {
        Events.g.AddListener<LevelEnteringEvent>(LevelEntered);
    }

    void LevelEntered(LevelEnteringEvent e)
    {
        print("level entered");
        switch (e.levelType)
        {
            case LevelType.Starting:
                _iMusicId = 1;
                break;
            case LevelType.Normal:
                _iMusicId = 1;
                break;
            case LevelType.Separated:
                _iMusicId = 2;
                break;
            case LevelType.Combined:
                _iMusicId = 3;
                break;
            default:
                break;
        }
        if (_iCurrentMusicId != _iMusicId)
        {
            PlayMusicById(_iMusicId);
            _iCurrentMusicId = _iMusicId;
        }
			
    }

    private void PlayMusicById(int musicId)
    {
        while (gameObject.GetComponent<AudioSource>().volume > 0)
        {
            gameObject.GetComponent<AudioSource>().volume -= 0.5f * Time.deltaTime;
						
            if (gameObject.GetComponent<AudioSource>().volume < 0.1f)
            {										
                switch (musicId)
                {
                    case 1:
                        gameObject.GetComponent<AudioSource>().clip = beginMusic;
                        break;
                    case 2:
                        gameObject.GetComponent<AudioSource>().clip = sadMusic;

                        break;
                    case 3:
                        gameObject.GetComponent<AudioSource>().clip = happyMusic;
                        break;
                    default:
                        break;
                }
                gameObject.GetComponent<AudioSource>().Play();
                break;
            }
        }
        while (gameObject.GetComponent<AudioSource>().volume < 1)
        {
            gameObject.GetComponent<AudioSource>().volume += 0.5f * Time.deltaTime;
        }
    }
    
    
}

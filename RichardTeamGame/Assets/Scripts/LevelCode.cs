using UnityEngine;
using System.Collections;

public class LevelCode : MonoBehaviour
{
    private bool playerOneEnter, playerTwoEnter;

    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.

    //var fadeImage;
    private bool sceneStarting = true;      // Whether or not the scene is still fading in.
    // Use this for initialization
    void Start()
    {
        if (Application.loadedLevelName == "sadBegin")
        {
						
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        if (Application.loadedLevelName == "happyBegin")
        {
						
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        if (Application.loadedLevelName == "beforeReunion1")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        //fadeImage = GameObject.FindWithTag ("Fade").GetComponent<Image> ();

    }
	
    // Update is called once per frame
    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.LoadLevel("StartScreen");
        }

        if (playerOneEnter && playerTwoEnter)
        {
            EndScene();
        }
        if (Application.loadedLevelName == "StartScreen")
        {
            if (Input.anyKeyDown)
            {
                EndScene();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            EndScene();
        }
        if (Application.loadedLevelName == "reunion2" || Application.loadedLevelName == "reunion3")
        {
            if (playerOneEnter)
            {
                EndScene();
            }
        }
    }
    void OnEnable()
    {
        Events.g.AddListener<PlayerEnterLevelDoorEvent>(PlayerEnter);
        Events.g.AddListener<PlayerExitLevelDoorEvent>(PlayerExit);
    }
	
    void OnDisable()
    {
        Events.g.RemoveListener<PlayerEnterLevelDoorEvent>(PlayerEnter);
        Events.g.RemoveListener<PlayerExitLevelDoorEvent>(PlayerExit);
    }
    void PlayerEnter(PlayerEnterLevelDoorEvent e)
    {
        if (e.isPlayerOne)
        {
            playerOneEnter = true;
        } else
        {
            playerTwoEnter = true;
        }
    }
    void PlayerExit(PlayerExitLevelDoorEvent e)
    {
        if (e.isPlayerOne)
        {
            playerOneEnter = false;
        } else
        {
            playerTwoEnter = false;
        }
    }

    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        GUI.color = Color.Lerp(GUI.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
	
	
    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        GUI.color = Color.Lerp(GUI.color, Color.black, fadeSpeed * Time.deltaTime);
    }
	
	
    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();
		
        // If the texture is almost clear...
        if (GUI.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
            GUI.color = Color.clear;
            GUI.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }
	
	
    public void EndScene()
    {
        // Make sure the texture is enabled.
        //GUI.enabled = true;
		
        // Start fading towards black.
        //FadeToBlack ();
		
        // If the screen is almost black...
        //if (GUI.color.a >= 0.95f) {
        // ... reload the level.
        Application.LoadLevel(Application.loadedLevel + 1);
        //}
    }

}

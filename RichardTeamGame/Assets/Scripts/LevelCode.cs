using UnityEngine;
using System.Collections;

public class LevelCode : MonoBehaviour
{
		private bool playerOneEnter, playerTwoEnter;
		public GameObject bgMusic;
		public GameObject bgMusicSad;
		public GameObject bgMusicHappy;
		// Use this for initialization
		void Start ()
		{
				/*
				if (Application.loadedLevelName == "StartScreen") {
						DontDestroyOnLoad (bgMusic);
				}*/
				if (Application.loadedLevelName == "sadBegin") {
						//DontDestroyOnLoad (bgMusicSad);
						Application.LoadLevel (Application.loadedLevel + 1);
				}
				if (Application.loadedLevelName == "happyBegin") {
						DontDestroyOnLoad (bgMusicHappy);
						Application.LoadLevel (Application.loadedLevel + 1);
				}
				if (Application.loadedLevelName == "beforeReunion1") {
						Application.LoadLevel (Application.loadedLevel + 1);
				}

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}

				if (Input.GetKeyDown (KeyCode.Backspace)) {
						Application.LoadLevel ("StartScreen");
				}

				if (playerOneEnter && playerTwoEnter) {
						Application.LoadLevel (Application.loadedLevel + 1);
				}
				if (Application.loadedLevelName == "StartScreen") {
						if (Input.anyKeyDown) {
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				}
				if (Input.GetKeyDown (KeyCode.N)) {
						Application.LoadLevel (Application.loadedLevel + 1);
				}
				if (Application.loadedLevelName == "reunion2" || Application.loadedLevelName == "reunion3") {
						if (playerOneEnter) {
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				}
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
		void PlayerEnter (PlayerEnterLevelDoorEvent e)
		{
				if (e.isPlayerOne) {
						playerOneEnter = true;
				} else {
						playerTwoEnter = true;
				}
		}
		void PlayerExit (PlayerExitLevelDoorEvent e)
		{
				if (e.isPlayerOne) {
						playerOneEnter = false;
				} else {
						playerTwoEnter = false;
				}
		}

}

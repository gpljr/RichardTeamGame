using UnityEngine;
using System.Collections;

public class LevelCode : MonoBehaviour
{
		private bool playerOneEnter, playerTwoEnter;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
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

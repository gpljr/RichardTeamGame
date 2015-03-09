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
						print ("next level");
				}
				if (Application.loadedLevelName == "StartScreen") {
						if (Input.anyKeyDown) {
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

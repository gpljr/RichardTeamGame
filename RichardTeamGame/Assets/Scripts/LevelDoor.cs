using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour
{
		
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
				if (other.gameObject.tag == "Player1") {
						Events.g.Raise (new PlayerEnterLevelDoorEvent (isPlayerOne: true));
				}
				if (other.gameObject.tag == "Player2") {
						Events.g.Raise (new PlayerEnterLevelDoorEvent (isPlayerOne: false));
				}
		}
		void OnTriggerExit2D (Collider2D other)
		{
				if (other.gameObject.tag == "Player1") {
						Events.g.Raise (new PlayerExitLevelDoorEvent (isPlayerOne: true));
				}
				if (other.gameObject.tag == "Player2") {
						Events.g.Raise (new PlayerExitLevelDoorEvent (isPlayerOne: false));
				}
		}
}

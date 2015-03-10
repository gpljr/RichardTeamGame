using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour
{
		[SerializeField]
		private bool
				isReunion;
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
						if (isReunion) {
								other.isTrigger = true;
						}
				}
				if (other.gameObject.tag == "Player2") {
						Events.g.Raise (new PlayerEnterLevelDoorEvent (isPlayerOne: false));
						if (isReunion) {
								other.isTrigger = true;
						}
				}
		}
		void OnTriggerExit2D (Collider2D other)
		{
				if (other.gameObject.tag == "Player1") {
						Events.g.Raise (new PlayerExitLevelDoorEvent (isPlayerOne: true));
						if (isReunion) {
								other.isTrigger = false;
						}
				}
				if (other.gameObject.tag == "Player2") {
						Events.g.Raise (new PlayerExitLevelDoorEvent (isPlayerOne: false));
						if (isReunion) {
								other.isTrigger = false;
						}
				}
		}
}

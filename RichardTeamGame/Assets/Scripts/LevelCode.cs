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
		}
		void OnTriggerEnter (Collider2D other)
		{
				if (other.gameObject.tag == "Player1") {
						playerOneEnter = true;
				}
				if (other.gameObject.tag == "Player2") {
						playerTwoEnter = true;
				}
		}
		void OnTriggerExit (Collider2D other)
		{
				if (other.gameObject.tag == "Player1") {
						playerOneEnter = false;
				}
				if (other.gameObject.tag == "Player2") {
						playerTwoEnter = false;
				}
		}
}

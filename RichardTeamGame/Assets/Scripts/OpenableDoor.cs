using UnityEngine;
using System.Collections;

public class OpenableDoor : MonoBehaviour
{
		[SerializeField]
		int
				triggerNumber = 1;
		[SerializeField]
		GameObject
				trigger1;
		[SerializeField]
		GameObject
				trigger2;
		[SerializeField]
		Vector2
				doorMove = new Vector2 (1, 0);

		private bool _isOpened;
		private Vector3 originalPosition;
		// Use this for initialization
		void Start ()
		{
				originalPosition = this.transform.position;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				switch (triggerNumber) {
				case 1:
						if (trigger1.GetComponent<TriggerForDoor> ().isTriggered) {
								if (!_isOpened) {
										OpenDoor ();
								}
						} else {
								CloseDoor ();
						}
						break;
				case 2:
						if (trigger1.GetComponent<TriggerForDoor> ().isTriggered && trigger2.GetComponent<TriggerForDoor> ().isTriggered) {
								if (!_isOpened) {
										OpenDoor ();
								}
						} else {
								CloseDoor ();
						}
						break;
				default:
						break;
				}
		}
		void OpenDoor ()
		{
				this.transform.position += new Vector3 (doorMove.x, doorMove.y, 0);

				_isOpened = true;
		}
		void CloseDoor ()
		{
				this.transform.position = originalPosition;

				_isOpened = false;
		}
}

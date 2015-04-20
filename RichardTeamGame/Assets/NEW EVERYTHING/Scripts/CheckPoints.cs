using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private float temp1x;
	private float temp1y;
	private float temp2x;
	private float temp2y;
	public Transform player1;
	public Transform player1Picture;
	public Transform player2;
	public Transform player2Picture;
	public GameObject Check1;
	public GameObject Check2;


	// Use this for initialization
	void Start () {
	
		temp1x = player1.position.x;
		temp1y = player1.position.y;
		temp2x = player2.position.x;
		temp2y = player2.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			player1.transform.position = new Vector3 (temp1x,temp1y, 0);
			player1Picture.transform.position = new Vector3 (temp1x, temp1y, 0);
			player2.transform.position = new Vector3 (temp2x, temp2y, 0);
			player2Picture.transform.position = new Vector3 (temp2x, temp2y, 0);
		}

		if (Check1.GetComponent<CheckPointTrigger> ().isTriggered && Check2.GetComponent<CheckPointTrigger> ().isTriggered2 || Check1.GetComponent<CheckPointTrigger> ().isTriggered2 && Check2.GetComponent<CheckPointTrigger> ().isTriggered) {
			Debug.Log ("getting info");
			temp1x = player1.position.x;
			temp1y = player1.position.y;
			temp2x = player2.position.x;
			temp2y = player2.position.y;
			Check1.GetComponent<CheckPointTrigger> ().isTriggered = false;
			Check1.GetComponent<CheckPointTrigger> ().isTriggered2 = false;
			Check2.GetComponent<CheckPointTrigger> ().isTriggered = false;
			Check2.GetComponent<CheckPointTrigger> ().isTriggered2 = false;
			}


	}
}

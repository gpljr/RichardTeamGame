using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private float temp1x;
	private float temp1y;
	private float temp2x;
	private float temp2y;
	private bool checkPointSaved = false;
	public Transform player1;
	public Transform player1Picture;
	public Transform player2;
	public Transform player2Picture;
	public GameObject Check1;
	public GameObject Check2;
	public static bool hit = false;
	public float check1Newx = 100f;
	public float check1Newy = 100f;
	public float check2Newx = 100f;
	public float check2Newy = 100f;


	// Use this for initialization
	void Start () {
		hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(checkPointSaved){
			player1.transform.position = new Vector3 (temp1x,temp1y, 0);
			player1Picture.transform.position = new Vector3 (temp1x, temp1y, 0);
			player2.transform.position = new Vector3 (temp2x, temp2y, 0);
			player2Picture.transform.position = new Vector3 (temp2x, temp2y, 0);
			}
			else{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (hit) {
			if(checkPointSaved){
				player1.transform.position = new Vector3 (temp1x,temp1y, 0);
				player1Picture.transform.position = new Vector3 (temp1x, temp1y, 0);
				player2.transform.position = new Vector3 (temp2x, temp2y, 0);
				player2Picture.transform.position = new Vector3 (temp2x, temp2y, 0);
				hit = false;
			}
			else{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (Check1.GetComponent<CheckPointTrigger> ().isTriggered && Check2.GetComponent<CheckPointTrigger> ().isTriggered2 || Check1.GetComponent<CheckPointTrigger> ().isTriggered2 && Check2.GetComponent<CheckPointTrigger> ().isTriggered) {
			checkPointSaved = true;
			temp1x = player1.position.x;
			temp1y = player1.position.y;
			temp2x = player2.position.x;
			temp2y = player2.position.y;
			Check1.transform.position = new Vector3(check1Newx, check1Newy, 0f);
			Check2.transform.position = new Vector3(check2Newx, check2Newy, 0f);
			Check1.GetComponent<CheckPointTrigger> ().isTriggered = false;
			Check1.GetComponent<CheckPointTrigger> ().isTriggered2 = false;
			Check2.GetComponent<CheckPointTrigger> ().isTriggered = false;
			Check2.GetComponent<CheckPointTrigger> ().isTriggered2 = false;
			}


	}
}

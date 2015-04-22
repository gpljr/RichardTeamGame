using UnityEngine;
using System.Collections;

public class CombinedCheckpoint : MonoBehaviour {

	private float temp1x;
	private float temp1y;
	private bool checkPointSaved = false;
	public Transform player1;
	public Transform player1Picture;
	public GameObject Check1;
	public static bool hitC = false;
	// Use this for initialization
	void Start () {
		hitC = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(checkPointSaved){
				player1.transform.position = new Vector3 (temp1x,temp1y, 0);
				player1Picture.transform.position = new Vector3 (temp1x, temp1y, 0);
			}
			else{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		
		if (hitC) {
			if(checkPointSaved){
				player1.transform.position = new Vector3 (temp1x,temp1y, 0);
				player1Picture.transform.position = new Vector3 (temp1x, temp1y, 0);
				hitC = false;
			}
			else{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		
		if (Check1.GetComponent<CheckPointTrigger> ().isTriggered3) {
			checkPointSaved = true;
			temp1x = player1.position.x;
			temp1y = player1.position.y;
			Check1.GetComponent<CheckPointTrigger> ().isTriggered3 = false;
		}
		
		
	}
}

using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public GameObject trigger1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (trigger1.GetComponent<TriggerForDoor> ().isTriggered) {
						Destroy (this.gameObject);
				}
	}
}

using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
				}

		if(Input.GetKeyDown (KeyCode.Backspace)){
			Application.LoadLevel("StartScreen"); 
		}
	}
}

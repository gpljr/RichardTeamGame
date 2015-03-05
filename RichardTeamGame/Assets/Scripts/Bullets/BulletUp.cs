using UnityEngine;
using System.Collections;

public class BulletUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position += new Vector3 (0f, 0.1f, 0f);
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2") {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (other.gameObject.tag == "BulletDestroyer") {
			Destroy (this.gameObject);
				}
	}

}

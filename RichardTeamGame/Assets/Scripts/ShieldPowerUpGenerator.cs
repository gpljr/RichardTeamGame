using UnityEngine;
using System.Collections;

public class ShieldPowerUpGenerator : MonoBehaviour {

	private float timeLeft = -1f;
	public static bool generate = true;

	public GameObject ShieldPowerUp;


	// Use this for initialization
	void Start () {
		generate = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (generate) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0f) {
				float powerUpx = Random.Range (-8f, 8f);
				float powerUpy = Random.Range (3f, 15f);
				Instantiate (ShieldPowerUp, new Vector3 (powerUpx, powerUpy, 0f), Quaternion.identity);
				timeLeft = 3f;
			}

		}
	}
}

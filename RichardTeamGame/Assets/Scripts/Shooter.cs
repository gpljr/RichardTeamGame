using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	private float timeBetweenShots = 3f;
	public GameObject BulletType;
	public float shotTime = 3f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timeBetweenShots -= Time.deltaTime;

		if (timeBetweenShots < 0) {
			Instantiate (BulletType, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			timeBetweenShots = shotTime;
		}


	}
}

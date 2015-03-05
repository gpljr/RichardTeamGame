using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {


	public static bool shrinkShield = true;
	private bool bulletStorm = false;

	private float timeLeft = -1f;
	private float timeUntilBulletStorm = 10f;
	private float bulletStormLength = 7f;

	public GameObject BulletUp;
	public GameObject BulletDown;
	public GameObject BulletLeft;
	public GameObject BulletRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (!bulletStorm) {
			if (shrinkShield) {
				Vector3 theScale = transform.localScale;
				theScale.x *= 0.9996f;
				theScale.y *= 0.9996f;
				transform.localScale = theScale;
			} else if (!shrinkShield) {
				Vector3 theScale = transform.localScale;
				theScale.x *= 1.1f;
				theScale.y *= 1.1f;
				transform.localScale = theScale;
				shrinkShield = true;
			}
		}



	}

	void Update (){

		timeUntilBulletStorm -= Time.deltaTime;
		if (timeUntilBulletStorm > 0) {
			GameObject.FindWithTag ("Timer").guiText.text = timeUntilBulletStorm.ToString ("f0");
				}
		if (timeUntilBulletStorm < 0) {
			bulletStorm = true;
			ShieldPowerUpGenerator.generate = false;
			GameObject.FindWithTag ("Timer").guiText.text = "BULLETSTORM!!!";
				}


		if (bulletStorm) {
			bulletStormLength -= Time.deltaTime;
			timeLeft -= Time.deltaTime;
			if(timeLeft < 0) {
			BulletStorm ();
				timeLeft = 0.2f;
			}
			if(bulletStormLength < 0){
				bulletStorm = false;
				ShieldPowerUpGenerator.generate = true;
				bulletStormLength = 7f;
				timeUntilBulletStorm = 15f;
			}
		}
		
		/*if(Input.GetKeyDown (KeyCode.Space)){
			if(shrinkShield){
				shrinkShield = false;
			}
			else{
				shrinkShield = true;
			}
		}*/
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Bullet") {
			Destroy (other.gameObject);
		}
	}

	void BulletStorm(){

			float bulletUpx = Random.Range (-12f, 10f);
			float bulletDownx = Random.Range (-12f, 10f);
			float bulletRighty = Random.Range (0f, 18f);
			float bulletLefty = Random.Range (0f, 18f);

		Instantiate (BulletUp, new Vector3 (bulletUpx, -5, 0f), Quaternion.identity);
		Instantiate (BulletDown, new Vector3 (bulletDownx, 27f, 0f), Quaternion.identity);
		Instantiate (BulletLeft, new Vector3 (16f, bulletLefty, 0f), Quaternion.identity);
		Instantiate (BulletRight, new Vector3 (-19f, bulletRighty, 0f), Quaternion.identity);



	}
}

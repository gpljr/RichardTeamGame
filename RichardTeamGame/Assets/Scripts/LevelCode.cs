using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelCode : MonoBehaviour
{
		[SerializeField]
		float
				_timeToFadeIn ;
		[SerializeField]
		float
				_timeToFadeOut ;
		[SerializeField]
		AnimationCurve
				_fadeCurve;
		private Image _image;

		private bool playerOneEnter, playerTwoEnter;
		public bool inFading = true;

		// Use this for initialization
		void Start ()
		{
				Cursor.visible = false;
				if (Application.loadedLevelName == "sadBegin") {
		
						Application.LoadLevel (Application.loadedLevel + 1);
				} 
				if (Application.loadedLevelName == "happyBegin") {
						
						Application.LoadLevel (Application.loadedLevel + 1);
				} 
				if (Application.loadedLevelName == "beforeReunion1") {
						Application.LoadLevel (Application.loadedLevel + 1);
				} 
				_image = GameObject.FindWithTag ("Fade").GetComponent<Image> ();
				StartScene ();
		}
	
		// Update is called once per frame
		void Update ()
		{

            

				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}

				if (Input.GetKeyDown (KeyCode.Backspace)) {
						Application.LoadLevel ("StartScreen");
				}

				if (playerOneEnter && playerTwoEnter) {
						EndScene ();
				}
				if (Application.loadedLevelName == "StartScreen") {
						if (Input.anyKeyDown) {
								EndScene ();
						}
				}
				if (Input.GetKeyDown (KeyCode.N)) {
						EndScene ();
				}
				if (Application.loadedLevelName == "reunion3") {
						if (playerOneEnter) {
								EndScene ();
						}
				}
				if (Application.loadedLevelName == "Demo5") {
						if (playerOneEnter && playerTwoEnter) {
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				}
				if (Application.loadedLevelName == "reunion2") {
						if (playerOneEnter) {
								Application.LoadLevel (Application.loadedLevel + 1);
						}
				}
		}
		void OnEnable ()
		{
				Events.g.AddListener<PlayerEnterLevelDoorEvent> (PlayerEnter);
				Events.g.AddListener<PlayerExitLevelDoorEvent> (PlayerExit);
		}
	
		void OnDisable ()
		{
				Events.g.RemoveListener<PlayerEnterLevelDoorEvent> (PlayerEnter);
				Events.g.RemoveListener<PlayerExitLevelDoorEvent> (PlayerExit);
		}
		void PlayerEnter (PlayerEnterLevelDoorEvent e)
		{
				if (e.isPlayerOne) {
						playerOneEnter = true;
				} else {
						playerTwoEnter = true;
				}
		}
		void PlayerExit (PlayerExitLevelDoorEvent e)
		{
				if (e.isPlayerOne) {
						playerOneEnter = false;
				} else {
						playerTwoEnter = false;
				}
		}

		void StartScene ()
		{
				StartCoroutine (Fade (_timeToFadeIn, _fadeCurve, fadeIn: true));
		}

		private IEnumerator Fade (float timerDuration, AnimationCurve curve, bool fadeIn)
		{
				Color startColor = _image.color;
				Color newColor;
				float alpha;
				float timer = 0f;
				if ((timer < timerDuration * 0.8f && fadeIn) || (timer < timerDuration && !fadeIn)) {
						inFading = true;
				} 
				while (timer < timerDuration) {
						
						timer += Time.deltaTime;
						if (fadeIn) {
								alpha = 1f - curve.Evaluate (timer / timerDuration);
						} else {
								alpha = curve.Evaluate (timer / timerDuration);
						}
						newColor = new Color (startColor.r, startColor.g, startColor.b, alpha);
						_image.color = newColor;
						yield return null;
				}
				inFading = false;
				if (fadeIn) {
						alpha = 1f - curve.Evaluate (1f);
				} else {
						alpha = curve.Evaluate (1f);
				}
				newColor = new Color (startColor.r, startColor.g, startColor.b, alpha);
				_image.color = newColor;

		}
		IEnumerator FadeOut (float timerDuration, AnimationCurve curve)
		{
				yield return StartCoroutine (Fade (timerDuration, curve, fadeIn: false));
				Application.LoadLevel (Application.loadedLevel + 1);
		}
    

		public void EndScene ()
		{
				StartCoroutine (FadeOut (_timeToFadeOut, _fadeCurve));
				
		}

}

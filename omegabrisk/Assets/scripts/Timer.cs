using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public float timer;
	public Text counterText;
	public float seconds, minutes;
	private bool timeRunning;

	// Use this for initialization
	void Start () {
		timeRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRunning) {
			if (timer <= 0) {
				//si  le score de gameover est > alors on save
				if (PlayerPrefs.GetInt ("ScoreHaut") < PlayerPrefs.GetInt ("ScoreJeu")){
					PlayerPrefs.SetInt ("ScoreHaut", PlayerPrefs.GetInt ("ScoreJeu"));
					PlayerPrefs.SetInt ("ScoreJeu", 0);
					PlayerPrefs.SetInt ("ScorePersonnes", 0);
				}
				//launch passage
				UnityEngine.SceneManagement.SceneManager.LoadScene("gameover");
				timer = 0;
			} else {
				timer -= Time.deltaTime;
			}
			minutes = (int)timer / 60;
			seconds = ((int)timer) % 60;
			counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
		}
	}

	void StopTimer() {
		timeRunning = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	public float timer;
	public Text counterText;
	public float seconds, minutes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0) {
			print ("PERDU");
			timer = 0;
		} else {
			timer -= Time.deltaTime;
		}
		minutes = (int) timer / 60;
		seconds = ((int)timer) % 60;
		counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}
}

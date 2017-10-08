using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hospital : MonoBehaviour {

	public Text counterText;
	public GameObject timer;

	// Use this for initialization
	void Start () {
		counterText = GameObject.FindGameObjectWithTag("text").GetComponent<Text> () as Text;
		timer = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			timer.SendMessage("StopTimer");
			UnityEngine.SceneManagement.SceneManager.LoadScene ("questmenu");
			int i = PlayerPrefs.GetInt ("difficulte");
			augmenterScoreJeu (i*getTimer());
			augmenterScorePersonne (1);
			UnityEngine.SceneManagement.SceneManager.LoadScene("questmenu");
		}
	}

	public int getTimer() {
		string min = counterText.text.Substring(0,1);
		string sec = counterText.text.Substring (3);
		int rep = int.Parse (min)*60;
		rep += int.Parse (sec);
		return rep;
	}

	public void SaveScoreJeu(int scorejeu) {
		PlayerPrefs.SetInt("ScoreJeu", scorejeu);
	}

	public int getScoreJeu() {
		return PlayerPrefs.GetInt("ScoreJeu");
	}

	public void SaveScorePersonnesSauvees(int scorejeu) {
		PlayerPrefs.SetInt("ScorePersonnes", scorejeu);
	}

	public int getScorePersonnesSauvees() {
		return PlayerPrefs.GetInt("ScorePersonnes");
	}

	public void augmenterScoreJeu(int aug) {
		SaveScoreJeu(getScoreJeu() + aug);
	}

	public void augmenterScorePersonne(int aug) {
		SaveScorePersonnesSauvees(getScorePersonnesSauvees() + aug);
	}

	public void diminuerScoreJeu(int dimin) {
		SaveScoreJeu(getScoreJeu() - dimin);
	}

	public void diminuerScorePersonne(int dimin) {
		SaveScorePersonnesSauvees(getScorePersonnesSauvees() - dimin);
	}
}

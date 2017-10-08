using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endscore : MonoBehaviour {
	public Text scoreJeu;
	public Text scorePersonnesSauvees;
	public Text scoreHaut;

	// Use this for initialization
	void Start () {
		scoreJeu.text = getScoreJeu().ToString();
		scorePersonnesSauvees.text = getScorePersonnesSauvees().ToString();
		scoreHaut.text = getScoreHaut().ToString();
	}

	// Update is called once per frame
	void Update () {
		SaveScoreJeu(int.Parse(scoreJeu.text));
		SaveScorePersonnesSauvees(int.Parse(scorePersonnesSauvees.text));
		SaveScoreHaut(int.Parse(scoreHaut.text));
	}

	// Score de la partie
	public void SaveScoreJeu(int scorejeu) {
		PlayerPrefs.SetInt("ScoreJeu", scorejeu);
	}

	public int getScoreJeu() {
		return PlayerPrefs.GetInt("ScoreJeu");
	}

	// Score du nombre de personnes sauvees
	public void SaveScorePersonnesSauvees(int scorejeu) {
		PlayerPrefs.SetInt("ScorePersonnes", scorejeu);
	}

	public int getScorePersonnesSauvees() {
		return PlayerPrefs.GetInt("ScorePersonnes");
	}

	// Score le plus haut - highscore
	public void SaveScoreHaut(int scorejeu) {
		PlayerPrefs.SetInt("ScoreHaut", scorejeu);
	}

	public int getScoreHaut() {
		return PlayerPrefs.GetInt("ScoreHaut");
	}

}

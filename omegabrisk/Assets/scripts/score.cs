using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public Text scoreJeu;
    public Text scorePersonnesSauvees;

    // Use this for initialization
    void Start () {
        scoreJeu.text = getScoreJeu().ToString();
        scorePersonnesSauvees.text = getScorePersonnesSauvees().ToString();
    }
	
	// Update is called once per frame
	void Update () {
        SaveScoreJeu(int.Parse(scoreJeu.text));
        SaveScorePersonnesSauvees(int.Parse(scorePersonnesSauvees.text));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void passagescene(string nomscene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomscene);
        print("ca merche pas");
    }
}

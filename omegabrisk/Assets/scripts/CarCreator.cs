using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreator : MonoBehaviour {
	public Transform car;
	public Transform cps;
	public int frequency;
	private float deltaTime;

	// Use this for initialization
	void Start () {
		deltaTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (deltaTime > frequency) {
			if (Random.Range (0, 10) <= 1) {
				Instantiate (cps, GetComponent<Transform> ().position - new Vector3 (30, 0, 0), Quaternion.identity);
			} else {
				Instantiate (car, GetComponent<Transform> ().position - new Vector3 (30, 0, 0), Quaternion.identity);
			}
			deltaTime = 0f;
		}
	}
}

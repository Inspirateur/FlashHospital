using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenerationRoad : MonoBehaviour {
	public Transform platform;
	public Transform hospital;
	public Transform car;
	public Transform cps; //(camion c'est pas sorcier) tuuut
	public Transform cardtor;
	public Transform carctor;
	private int diff;
	public int roadSize;
	public int angleLimit;
	public int angleVar;
	public float timer;
	public Text counterText;
	public float seconds, minutes;
	private float x, y, rz, newrz;
	private float vehicleFreq, cpsFreq; 
	private int sheitan;
	// Use this for initialization
	void Start () {
		diff = PlayerPrefs.GetInt ("difficulte");
		vehicleFreq = diff / 3f;
		cpsFreq = diff / 10f;
		x = 0;
		y = 0;
		rz = 0;
		timer = 190;
		Instantiate (cardtor, new Vector3(50, 10, 0), Quaternion.identity);
		sheitan = 50;
		for (int i = 0; i < roadSize; i++) {
			//Generate new platform
			newrz = Mathf.Deg2Rad*((Random.Range(-angleVar,angleVar)%angleVar+(rz*Mathf.Rad2Deg))%angleLimit);
			x += sheitan*(Mathf.Cos (rz)+Mathf.Cos (newrz));
			y += sheitan*(Mathf.Sin (rz)+Mathf.Sin (newrz));
			rz = newrz;
			Instantiate(platform, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
			//Generate new vehicle
			if (Random.Range (0, 100) / 100f <= cpsFreq) {
				//It's a truck
				if (Random.Range (0, 100) / 100f <= vehicleFreq) {
					Instantiate(cps, new Vector3(x, y+20, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
				}
			} else {
				//It's a car
				if (Random.Range (0, 100) / 100f <= vehicleFreq) {
					Instantiate(car, new Vector3(x, y+20, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
				}
			}
		}
		newrz = 0;
		x += sheitan*(Mathf.Cos (rz)+Mathf.Cos (newrz));
		y += sheitan*(Mathf.Sin (rz)+Mathf.Sin (newrz));
		rz = newrz;
		Instantiate(platform, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
		Instantiate(hospital, new Vector3(x, y+20, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
		newrz = 0;
		x += sheitan*(Mathf.Cos (rz)+Mathf.Cos (newrz));
		y += sheitan*(Mathf.Sin (rz)+Mathf.Sin (newrz));
		rz = newrz;
		Instantiate(platform, new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
		Instantiate(carctor, new Vector3(x, y+10, 0), Quaternion.Euler(new Vector3(0, 0, rz*Mathf.Rad2Deg)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

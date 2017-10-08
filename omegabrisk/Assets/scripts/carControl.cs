using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControl : MonoBehaviour {
	public float speed;
	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;


	// Use this for initialization
	void Start () {
		backWheel.useMotor = true;
		frontWheel.useMotor = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		JointMotor2D motor = new JointMotor2D { motorSpeed = speed, maxMotorTorque = 10000 };
		backWheel.motor = motor;
		frontWheel.motor = motor;
	}
}

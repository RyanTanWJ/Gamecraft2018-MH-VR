using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject gearObject;
	private Gear gear;

	private void Start() {
		gear = gearObject.GetComponent<Gear>();
	}

	private void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow)){
			gear.Rotate(gear.RotationSpeed);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			gear.Rotate(-gear.RotationSpeed);
		}
	}
}

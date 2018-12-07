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
	}
}

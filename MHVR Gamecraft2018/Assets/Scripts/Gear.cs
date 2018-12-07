using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

	[SerializeField]
	private float _size;
	private float rotationSpeed = 10;

	public float size {
		get { return _size; }
		set { _size = value; }
	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Rotate(rotationSpeed);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			Rotate(-rotationSpeed);
		}
	}

	public void Rotate(float degrees) {
		transform.Rotate(0,0, degrees);

		foreach (Gear child_gear in GetComponentsInChildren<Gear>()) {
			if (child_gear.transform != transform) {
				child_gear.Rotate(-degrees);
			}
		}
	}
}

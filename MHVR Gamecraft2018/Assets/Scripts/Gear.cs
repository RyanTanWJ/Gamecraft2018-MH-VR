using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

	[SerializeField]
	private float _size;

	public float Size {
		get { return _size; }
		set { _size = value; }
	}

	public float RotationSpeed {
		get { return 10; }
	}

	public Vector3 Position { get; set; }

	public void Start() {
		Position = transform.position;
	}

	public void EarlyUpdate()
	{
		transform.position = Position;
	}

	public void FixedUpdate()
	{
		transform.position = Position;
	}

	public void LateUpdate() {
		transform.position = Position;
	}

	public void Rotate(float degrees) {


		Gear[] allGears = GetComponentsInChildren<Gear>();

		foreach (Gear child_gear in allGears) {
			if (child_gear.transform != transform) {
				child_gear.Rotate(-degrees * child_gear.Size * 2);
			}
		}

		transform.Rotate(0, 0, degrees);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

	[SerializeField]
	private float _size;
  /// <summary>
  /// If the gear is in phase with the main gear
  /// </summary>
  [SerializeField]
  bool inPhase;

  public float Size {
		get { return _size; }
		set { _size = value; }
	}

	public float RotationSpeed {
		get { return 10; }
	}

	public void Rotate(float degrees)
  {
    Debug.Log(name + " is rotating by " + degrees + " degrees");
    if (inPhase)
    {
      transform.Rotate(0, 0, degrees);
    }
    else
    {
      transform.Rotate(0, 0, -degrees);
    }
	}
}

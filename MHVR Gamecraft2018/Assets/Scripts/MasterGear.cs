using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGear : Gear
{

	bool isActive = false;

	[SerializeField]
	List<GameObject> ControlStars;

	public void ActivateMasterGear(bool player)
	{
		isActive = true;
		ActivateGear(player);
		ControlStars[player ? 1 : 0].SetActive(true);
	}

	public void DeactivateMasterGear()
	{
		isActive = false;
		DeactivateGear();
		foreach (GameObject cs in ControlStars)
		{
			cs.SetActive(false);
		}
	}

	public bool Active
	{
		get { return isActive; }
	}
}

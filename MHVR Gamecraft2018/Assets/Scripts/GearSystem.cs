﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSystem : MonoBehaviour
{

	[SerializeField]
	MasterGear masterGear;
	[SerializeField]
	List<Gear> normalGearsInSystem;

	/// <summary>
	/// Activates the Master Gear of the system
	/// </summary>
	public void Activate(bool player)
	{
		masterGear.ActivateMasterGear(player);
		foreach (Gear gear in normalGearsInSystem)
		{
			gear.ActivateGear(player);
		}
	}

	/// <summary>
	/// Activates the Master Gear of the system
	/// </summary>
	public void Deactivate()
	{
		masterGear.DeactivateMasterGear();
		foreach (Gear gear in normalGearsInSystem)
		{
			gear.DeactivateGear();
		}
	}

	/// <summary>
	/// Rotates the gears in the system only if Master Gear is active
	/// </summary>
	/// <param name="deg"></param>
	public void Rotate(float deg)
	{
		if (!masterGear.Active)
		{
			return;
		}
		RotateGearSystem(deg);
	}

	private void RotateGearSystem(float deg)
	{
		masterGear.Rotate(masterGear.Size, deg);
		foreach (Gear gear in normalGearsInSystem)
		{
			gear.Rotate(masterGear.Size, deg);
		}
	}
}

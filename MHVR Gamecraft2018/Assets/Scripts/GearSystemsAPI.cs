using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSystemsAPI : MonoBehaviour {

  [SerializeField]
  List<GearSystem> gearSystems;
  int currActiveSystem = 0;

  private void Start()
  {
    foreach (GearSystem gs in gearSystems)
    {
      gs.Deactivate();
    }
    gearSystems[currActiveSystem].Activate();
  }

  /// <summary>
  /// Rotates the current active gear system
  /// </summary>
  /// <param name="clockwise">clockwise true; counter-clockwise otherwise</param>
  public void Rotate(bool clockwise)
  {
    if (clockwise)
    {
      gearSystems[currActiveSystem].Rotate(-1f);
    }
    else
    {
      gearSystems[currActiveSystem].Rotate(1f);
    }
  }

  /// <summary>
  /// Function to change gear system
  /// </summary>
  /// <param name="next">forward or backward change</param>
  public void ChangeGearSystem(bool next)
  {
    gearSystems[currActiveSystem].Deactivate();
    if (next)
    {
      currActiveSystem++;
      if (currActiveSystem == gearSystems.Count)
      {
        currActiveSystem = 0;
      }
    }
    else
    {
      currActiveSystem--;
      if (currActiveSystem < 0)
      {
        currActiveSystem = gearSystems.Count - 1;
      }
    }
    gearSystems[currActiveSystem].Activate();
  }
}

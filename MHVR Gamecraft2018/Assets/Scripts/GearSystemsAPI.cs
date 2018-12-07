using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSystemsAPI : MonoBehaviour
{

  [SerializeField]
  List<GearSystem> gearSystems;
  int p1ActiveSystem;
  int p2ActiveSystem;

  private void Start()
  {
    if (gearSystems.Count < 2)
    {
      Debug.LogError("Too few Gear Systems");
    }
    p1ActiveSystem = 0;
    p2ActiveSystem = gearSystems.Count - 1;
    UpdateGearSystem();
  }

  private void UpdateGearSystem()
  {
    foreach (GearSystem gs in gearSystems)
    {
      gs.Deactivate();
    }
    gearSystems[p1ActiveSystem].Activate(false);
    gearSystems[p2ActiveSystem].Activate(true);
  }

  /// <summary>
  /// Rotates the current active gear system
  /// </summary>
  /// <param name="playerSystem">false if player 1, otherwise player 2</param>
  /// <param name="clockwise">clockwise true; counter-clockwise otherwise</param>
  public void Rotate(bool playerSystem, bool clockwise)
  {
    if (playerSystem)
    {
      if (clockwise)
      {
        gearSystems[p1ActiveSystem].Rotate(-1f);
      }
      else
      {
        gearSystems[p1ActiveSystem].Rotate(1f);
      }
    }
    else
    {
      if (clockwise)
      {
        gearSystems[p2ActiveSystem].Rotate(-1f);
      }
      else
      {
        gearSystems[p2ActiveSystem].Rotate(1f);
      }
    }
  }

  /// <summary>
  /// Function to change gear system
  /// </summary>
  /// <param name="playerSystem">false if player 1, otherwise player 2</param>
  /// <param name="next">forward or backward change</param>
  public void ChangeGearSystem(bool playerSystem, bool next)
  {
    ChangeGearSystemNumbers(playerSystem, next);

    UpdateGearSystem();
    Debug.Log(p1ActiveSystem);
    Debug.Log(p2ActiveSystem);
  }
  private void ChangeGearSystemNumbers(bool playerSystem, bool next)
  {
    if (playerSystem)
    {
      if (next)
      {
        p1ActiveSystem = (p1ActiveSystem + 1) % gearSystems.Count;
        if (p2ActiveSystem == p1ActiveSystem)
        {
          ChangeGearSystemNumbers(playerSystem, next);
        }
      }
      else
      {
        p1ActiveSystem = (p1ActiveSystem + gearSystems.Count - 1) % gearSystems.Count;
        if (p2ActiveSystem == p1ActiveSystem)
        {
          ChangeGearSystemNumbers(playerSystem, next);
        }
      }
    }
    else
    {
      if (next)
      {
        p2ActiveSystem = (p2ActiveSystem + 1) % gearSystems.Count;
        if (p2ActiveSystem == p1ActiveSystem)
        {
          ChangeGearSystemNumbers(playerSystem, next);
        }
      }
      else
      {
        p2ActiveSystem = (p2ActiveSystem + gearSystems.Count - 1) % gearSystems.Count;
        if (p2ActiveSystem == p1ActiveSystem)
        {
          ChangeGearSystemNumbers(playerSystem, next);
        }
      }
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGear : Gear
{
  [SerializeField]
  Sprite HighlightedSprite;
  [SerializeField]
  Sprite RegularSprite;

  bool isActive = false;

  public void ActivateMasterGear()
  {
    isActive = true;
    GetComponent<SpriteRenderer>().sprite = HighlightedSprite;
  }

  public void DeactivateMasterGear()
  {
    isActive = false;
    GetComponent<SpriteRenderer>().sprite = RegularSprite;
  }

  public bool Active
  {
    get { return isActive; }
  }
}

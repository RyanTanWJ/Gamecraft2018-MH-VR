using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGear : Gear
{
  [SerializeField]
  List<Sprite> HighlightedSprites;
  [SerializeField]
  Sprite RegularSprite;

  bool isActive = false;

  public void ActivateMasterGear(bool player)
  {
    isActive = true;
    GetComponent<SpriteRenderer>().sprite = HighlightedSprites[player ? 1 : 0];
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

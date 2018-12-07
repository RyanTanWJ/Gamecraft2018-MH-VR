using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

  public delegate void BallExploded(Ball ball);
  public static event BallExploded BallExplodedEvent;

  internal void ExplodeBall()
  {
    Debug.Log("Ball exploded!");
    BallExplodedEvent(this);
  }
}

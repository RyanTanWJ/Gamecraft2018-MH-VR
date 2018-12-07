using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

  public delegate void BallExploded(Ball ball);
  public static event BallExploded BallExplodedEvent;

  [SerializeField]
  GameObject SpawnFX;

  public void PlayFX()
  {
    GameObject newFX = Instantiate(SpawnFX, transform.position, Quaternion.identity);
    Destroy(newFX, newFX.GetComponent<ParticleSystem>().main.duration);
  }

  internal void ExplodeBall()
  {
    PlayFX();
    Debug.Log("Ball exploded!");
    BallExplodedEvent(this);
  }
}

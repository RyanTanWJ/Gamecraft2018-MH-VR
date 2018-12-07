using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

  [SerializeField]
  Vector2 SpawnAreaTopLeftCorner;
  [SerializeField]
  Vector2 SpawnAreaBotRightCorner;

  BallPool ballPool;

  int ballSat = 4;
  const float delay = 3f;
  float time = 0;

  private void Start()
  {
    ballPool = GetComponentInChildren<BallPool>();
  }

  private void Update()
  {
    time += Time.deltaTime;
    if (time > delay)
    {
      for (int i = 0; i < ballSat; i++)
      {
        SpawnBall();
      }
      time = 0;
      //ballSat++;
    }
  }

  public void SpawnBall()
  {
    float x = Random.Range(SpawnAreaTopLeftCorner.x, SpawnAreaBotRightCorner.x);
    float y = Random.Range(SpawnAreaBotRightCorner.y, SpawnAreaTopLeftCorner.y);
    ballPool.GetBall().transform.position = new Vector3(x,y,0);
  }
}

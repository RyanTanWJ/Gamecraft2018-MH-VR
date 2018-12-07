using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour {

  [SerializeField]
  GameObject ballPrefab;
  List<GameObject> balls = new List<GameObject>();

  private void OnEnable()
  {
    Ball.BallExplodedEvent += ReturnBall;
  }

  private void OnDisable()
  {
    Ball.BallExplodedEvent -= ReturnBall;
  }

  public GameObject GetBall()
  {
    if (balls.Count <= 0)
    {
      return Instantiate(ballPrefab);
    }
    else
    {
      GameObject retBall = balls[0];
      balls.RemoveAt(0);
      return retBall;
    }
  }

  public void ReturnBall(Ball ball)
  {
    GameObject ballObj = ball.gameObject;
    ballObj.transform.position = transform.position;
    balls.Add(ballObj);
  }
}

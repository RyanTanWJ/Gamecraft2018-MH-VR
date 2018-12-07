using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour {

  int player;

  private void Start()
  {
    player = 0;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      ScoreGoal(player);
      collision.gameObject.GetComponent<Ball>().ExplodeBall();
    }
  }

  void ScoreGoal(int player)
  {
    Debug.Log("Player " + player + " scored!");
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour {

  [SerializeField]
  int player;

  [SerializeField]
  TMPro.TextMeshPro playerNumberText;

  private void Start()
  {
    if (player < 0)
    {
      playerNumberText.text = "X";
    }
    else
    {
      playerNumberText.text = player.ToString();
    }
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

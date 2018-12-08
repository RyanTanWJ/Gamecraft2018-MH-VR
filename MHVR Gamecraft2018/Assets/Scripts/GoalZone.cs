using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour {

	public delegate void Score(int player);
	public static event Score ScoreEvent;

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
			if (player > 0)
			{
				ScoreGoal(player);
			}
      SoundManager.PlaySound("Goal");
      collision.gameObject.GetComponent<Ball>().ExplodeBall();
    }
  }

  void ScoreGoal(int player)
  {
		ScoreEvent(player);
    //Debug.Log("Player " + player + " scored!");
  }
}

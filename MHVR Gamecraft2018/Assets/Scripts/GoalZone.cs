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

  [SerializeField]
  GameObject SpawnFX;

  public void PlayFX(Vector3 pos)
  {
    GameObject newFX = Instantiate(SpawnFX, pos, Quaternion.identity);
    Destroy(newFX, newFX.GetComponent<ParticleSystem>().main.duration);
  }

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
      PlayFX(collision.gameObject.transform.position);
      collision.gameObject.GetComponent<Ball>().ExplodeBall();
    }
  }

  void ScoreGoal(int player)
  {
		ScoreEvent(player);
    //Debug.Log("Player " + player + " scored!");
  }
}

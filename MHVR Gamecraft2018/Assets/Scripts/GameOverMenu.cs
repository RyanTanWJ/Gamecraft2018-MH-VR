using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

  [SerializeField]
  TMPro.TextMeshProUGUI Winner;
  [SerializeField]
  TMPro.TextMeshProUGUI TopPlayerScore;
  [SerializeField]
  TMPro.TextMeshProUGUI OtherPlayerScore;
  [SerializeField]
  Button ReturnToMainMenu;

  private void Start()
  {
    ReturnToMainMenu.onClick.AddListener(ReturnMainMenu);
  }

  public void PopulateCanvas(int player1score,int player2score)
  {
    if (player1score > player2score)
    {
      Winner.text = "Player 1 Wins!";
      TopPlayerScore.text = "Player 1 Score: " + player1score;
      TopPlayerScore.color = Color.blue;
      OtherPlayerScore.text = "Player 2 Score: " + player2score;
      OtherPlayerScore.color = Color.red;
    }
    else if (player1score < player2score)
    {
      Winner.text = "Player 2 Wins!";
      TopPlayerScore.text = "Player 2 Score: " + player2score;
      TopPlayerScore.color = Color.red;
      OtherPlayerScore.text = "Player 1 Score: " + player1score;
      OtherPlayerScore.color = Color.blue;
    }
    else
    {
      Winner.text = "It's A Draw!";
      TopPlayerScore.text = "Player 1 Score: " + player1score;
      TopPlayerScore.color = Color.blue;
      OtherPlayerScore.text = "Player 2 Score: " + player2score;
      OtherPlayerScore.color = Color.red;
    }
  }

  public void ReturnMainMenu()
  {
    ButtonController buttonController = new ButtonController();
    buttonController.LoadScene(0);
  }
}

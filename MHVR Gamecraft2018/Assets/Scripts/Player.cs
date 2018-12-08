using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public KeyCode Left { get; set; }
	public KeyCode Right { get; set; }
	public KeyCode Next { get; set; }
	public KeyCode Previous { get; set; }

	public int Score { get; set; }

	public static Player Initialise(int player_number) {
		Player newPlayer = new Player();

		switch(player_number) {
			case (1):
				newPlayer.Left = KeyCode.A;
				newPlayer.Right = KeyCode.D;
				newPlayer.Next = KeyCode.W;
				newPlayer.Previous = KeyCode.S;
				break;
			case (0):
				newPlayer.Left = KeyCode.LeftArrow;
				newPlayer.Right = KeyCode.RightArrow;
				newPlayer.Next = KeyCode.UpArrow;
				newPlayer.Previous = KeyCode.DownArrow;
				break;
			default:
				return null;
		}

		newPlayer.Score = 0;

		return newPlayer;
	}
}

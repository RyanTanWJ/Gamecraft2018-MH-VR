using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private const int NUM_PLAYERS = 2;
	Player[] players;

	void Start() {
		InitialiseGame();
	}

	void Update() {
		if (Input.GetKeyDown(players[0].Left)) {
			print("hello");
		}
	}

	private void InitialiseGame() {
		InitialisePlayers();
	}

	private void InitialisePlayers() {
		players = new Player[NUM_PLAYERS];
		for (int i = 0; i < NUM_PLAYERS; i++) {
			print("Create Player " + i);
			players[i] = Player.Initialise(i);
		}
	}
}

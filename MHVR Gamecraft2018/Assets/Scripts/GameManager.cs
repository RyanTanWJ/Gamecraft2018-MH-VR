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
		for (int i = 0; i < NUM_PLAYERS; i++) {
			if (Input.GetKey(players[i].Left)) {
				print("Player " + i + ": Left");
			}

			if (Input.GetKey(players[i].Right)) {
				print("Player " + i + ": Right");
			}

			if (Input.GetKeyDown(players[i].Next)) {
				print("Player " + i + ": Next");
			}

			if (Input.GetKeyDown(players[i].Previous)) {
				print("Player " + i + ": Previous");
			}
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

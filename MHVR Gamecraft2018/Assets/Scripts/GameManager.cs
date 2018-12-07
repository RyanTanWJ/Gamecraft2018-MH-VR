using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject GearSystemObject;
	GearSystemsAPI GearSystem;

	private const int NUM_PLAYERS = 2;
	Player[] players;

	void Start() {
		InitialiseGame();
	}

	void Update() {
		for (int i = 0; i < NUM_PLAYERS; i++) {
			if (Input.GetKey(players[i].Left)) {
				GearSystem.Rotate(false);
			}

			if (Input.GetKey(players[i].Right)) {
				GearSystem.Rotate(true);
			}

			if (Input.GetKeyDown(players[i].Next)) {
				GearSystem.ChangeGearSystem(true);
			}

			if (Input.GetKeyDown(players[i].Previous)) {
				GearSystem.ChangeGearSystem(false);
			}
		}
	}

	private void InitialiseGame() {
		GearSystem = GearSystemObject.GetComponent<GearSystemsAPI>();
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

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
			if (Input.GetKey(players[i].Left))
      {
        bool player = i == 0 ? false : true;
        GearSystem.Rotate(player,false);
			}

			if (Input.GetKey(players[i].Right))
      {
        bool player = i == 0 ? false : true;
        GearSystem.Rotate(player,true);
			}

			if (Input.GetKeyDown(players[i].Next))
      {
        bool player = i == 0 ? false : true;
        GearSystem.ChangeGearSystem(player,true);
			}

			if (Input.GetKeyDown(players[i].Previous))
      {
        bool player = i == 0 ? false : true;
        GearSystem.ChangeGearSystem(player,false);
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

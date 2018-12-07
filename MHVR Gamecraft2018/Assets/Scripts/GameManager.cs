using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject GearSystemObject;
	public TMPro.TextMeshProUGUI time, score1, score2;
	GearSystemsAPI GearSystem;

	private float gameDuration = 150;
	private float gameStartTime;

	private const int NUM_PLAYERS = 2;
	Player[] players;

	void Awake() {
		InitialiseGame();
	}

	void OnEnable(){
		GoalZone.ScoreEvent += ScorePlayer;
	}

	void OnDisable() {
		GoalZone.ScoreEvent -= ScorePlayer;
	}

	void Update() {
		for (int i = 0; i < NUM_PLAYERS; i++) {
			if (Input.GetKey(players[i].Left)) {
				bool player = i == 0 ? false : true;
				GearSystem.Rotate(player,false);
			}

			if (Input.GetKey(players[i].Right)) {
				bool player = i == 0 ? false : true;
				GearSystem.Rotate(player,true);
			}

			if (Input.GetKeyDown(players[i].Next)) {
				bool player = i == 0 ? false : true;
				GearSystem.ChangeGearSystem(player,true);
			}

			if (Input.GetKeyDown(players[i].Previous)) {
				bool player = i == 0 ? false : true;
				GearSystem.ChangeGearSystem(player,false);
			}
		}

		score1.text = "Player 1\nScore: " + players[0].Score;
		score2.text = "Player 2\nScore: " + players[1].Score;
		time.text = "Time Remaining\n" + (int)(gameDuration - Time.time - gameStartTime);
	}

	private void InitialiseGame() {
		GearSystem = GearSystemObject.GetComponent<GearSystemsAPI>();
		InitialisePlayers();
		PrefabManager.InitialiseBlockSprites();
		gameStartTime = Time.time;
	}

	private void ScorePlayer(int playerPlusOne) {
		players[playerPlusOne - 1].Score++;
	}

	private void InitialisePlayers() {
		players = new Player[NUM_PLAYERS];
		for (int i = 0; i < NUM_PLAYERS; i++) {
			print("Create Player " + i);
			players[i] = Player.Initialise(i);
		}
	}
}

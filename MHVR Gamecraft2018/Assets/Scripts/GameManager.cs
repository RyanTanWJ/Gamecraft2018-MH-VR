using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject GearSystemObject;
	public TMPro.TextMeshProUGUI time, score1, score2;
	GearSystemsAPI GearSystem;

	private float gameDuration = 30;
	private float gameStartTime;

	private const int NUM_PLAYERS = 2;
	Player[] players;

	private bool isPaused;

  [SerializeField]
  GameObject GameCanvas;

  [SerializeField]
  GameObject GameOverCanvas;

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
		if (!isPaused) {
			if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
				PauseGame();
			}

			for (int i = 0; i < NUM_PLAYERS; i++) {
				if (Input.GetKey(players[i].Left)) {
					bool player = i == 0 ? false : true;
					GearSystem.Rotate(player, false);
				}

				if (Input.GetKey(players[i].Right)) {
					bool player = i == 0 ? false : true;
					GearSystem.Rotate(player, true);
				}

				if (Input.GetKeyDown(players[i].Next)) {
					bool player = i == 0 ? false : true;
					GearSystem.ChangeGearSystem(player, true);
				}

				if (Input.GetKeyDown(players[i].Previous)) {
					bool player = i == 0 ? false : true;
					GearSystem.ChangeGearSystem(player, false);
				}
			} 
		} else {
			if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
				UnpauseGame();
		}
	}

		score1.text = "Player 1\nScore: " + players[0].Score;
		score2.text = "Player 2\nScore: " + players[1].Score;
		time.text = "Time Remaining\n" + (int)(gameDuration - Time.time - gameStartTime);

		if (gameDuration - Time.time - gameStartTime <= 0) {
			GameOver();
		}
	}

	private void GameOver() {
		PauseGame();
		ButtonController buttonController = new ButtonController();
		buttonController.hideObject(GameCanvas);
		ActivateGameOverCanvas();
	}

  private void ActivateGameOverCanvas() {
    GameOverCanvas.SetActive(true);
    GameOverCanvas.GetComponent<GameOverMenu>().PopulateCanvas(players[0].Score, players[1].Score);
  }

  private void InitialiseGame() {
		isPaused = false;
		GearSystem = GearSystemObject.GetComponent<GearSystemsAPI>();
		InitialisePlayers();
		PrefabManager.InitialiseBlockSprites();
		SpriteManager.InitialiseSprites();
		gameStartTime = Time.time;
	}

	private void ScorePlayer(int playerPlusOne) {
		players[playerPlusOne - 1].Score++;
	}

	private void InitialisePlayers() {
		players = new Player[NUM_PLAYERS];
		for (int i = 0; i < NUM_PLAYERS; i++) {
			//print("Create Player " + i);
			players[i] = Player.Initialise(i);
		}
	}

	private void PauseGame() {
		isPaused = true;
		Time.timeScale = 0;
	}

	private void UnpauseGame() {
		isPaused = false;
		Time.timeScale = 1;
	}
}

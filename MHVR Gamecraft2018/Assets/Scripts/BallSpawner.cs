using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	[SerializeField]
	Vector2 SpawnAreaTopLeftCorner;
	[SerializeField]
	Vector2 SpawnAreaBotRightCorner;

	BallPool ballPool;

	int ballSat = 1;
	const float delay = 1.5f;
	float time = 0;
	int ballCount;

	public int BallSat { get { return ballSat; } }

	private void Start() {
		ballPool = GetComponentInChildren<BallPool>();
		ballCount = 0;
	}

	private void OnEnable() {
		Ball.BallExplodedEvent += BallDestroyed;
	}

	private void OnDisable() {
		Ball.BallExplodedEvent -= BallDestroyed;
	}

	private void Update() {
		time += Time.deltaTime;
		if (time > delay) {
			for (int i = 0; i < ballSat; i++) {
				if (ballCount < ballSat) {
					SpawnBall();
				}
			}
		time = 0;
		}
	}

	public void SpawnBall() {
		float x = Random.Range(SpawnAreaTopLeftCorner.x, SpawnAreaBotRightCorner.x);
		float y = Random.Range(SpawnAreaBotRightCorner.y, SpawnAreaTopLeftCorner.y);
		GameObject ballObj = ballPool.GetBall();
		ballObj.transform.position = new Vector3(x,y,0);
		ballObj.GetComponent<Ball>().PlayFX();
		ballCount++;
	}

	public void IncreaseSaturation() {
		ballSat++;
	}

	private void BallDestroyed(Ball ball) {
		ballCount--;
	}
}

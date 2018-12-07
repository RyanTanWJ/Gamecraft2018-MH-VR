using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void LoadScene(int sceneNumber) {
		LoadScene(sceneNumber);
	}

	public void showObject(GameObject gameObject) {
		gameObject.SetActive(true);
	}

	public void hideObject(GameObject gameObject) {
		gameObject.SetActive(false);
	}

	public void QuitGame() {
		Application.Quit();
	}
}

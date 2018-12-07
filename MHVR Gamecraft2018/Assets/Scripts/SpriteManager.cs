using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

	private static Sprite LoadSprite(string filepath) {
		Sprite sprite = Resources.Load<Sprite>("Sprite/" + filepath);
		if (sprite == null) {
			Debug.LogError("Error loading sprite, path = [" + filepath + "]");
		}
		return sprite;
	}
}

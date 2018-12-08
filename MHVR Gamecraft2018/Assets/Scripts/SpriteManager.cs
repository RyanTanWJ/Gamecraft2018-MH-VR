using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

	public static Dictionary<string, Sprite> spriteList;

	public static void InitialiseSprites() {
		spriteList = new Dictionary<string, Sprite>();

		Sprite loader = LoadSprite("Star_red");
		spriteList.Add("Star_Red", loader);

		loader = LoadSprite("Star_blue");
		spriteList.Add("Star_Blue", loader);
	}

	private static Sprite LoadSprite(string filepath) {
		Sprite sprite = Resources.Load<Sprite>("Sprites/" + filepath);
		if (sprite == null) {
			Debug.LogError("Error loading sprite, path = [" + filepath + "]");
		}
		return sprite;
	}
}

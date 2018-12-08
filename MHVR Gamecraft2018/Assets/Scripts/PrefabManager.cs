using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockType = Block.BlockType;

public class PrefabManager : MonoBehaviour {

	public static Dictionary<BlockType, GameObject> blockPrefab;

	public static GameObject InitialiseBallSpawner() {
		return LoadPrefab("BallSpawner");
	}

	public static void InitialiseBlockSprites() {
		blockPrefab = new Dictionary<BlockType, GameObject>();

		GameObject flat1 = LoadPrefab("Blocks/flatblock_1");
		blockPrefab.Add(BlockType.flat1, flat1);
		GameObject flat2 = LoadPrefab("Blocks/flatblock_2");
		blockPrefab.Add(BlockType.flat2, flat2);
		GameObject flat3 = LoadPrefab("Blocks/flatblock_3");
		blockPrefab.Add(BlockType.flat3, flat3);

		GameObject l1 = LoadPrefab("Blocks/lblock_1");
		blockPrefab.Add(BlockType.l1, l1);
		GameObject l2 = LoadPrefab("Blocks/lblock_2");
		blockPrefab.Add(BlockType.l2, l2);
		GameObject l3 = LoadPrefab("Blocks/lblock_3");
		blockPrefab.Add(BlockType.l3, l3);

		GameObject t1 = LoadPrefab("Blocks/tblock_1");
		blockPrefab.Add(BlockType.t1, t1);
		GameObject t2 = LoadPrefab("Blocks/tblock_2");
		blockPrefab.Add(BlockType.t2, t2);
	}

	private static GameObject LoadPrefab(string path) {
		GameObject prefab = Resources.Load("Prefabs/" + path, typeof(GameObject)) as GameObject;
		if (prefab == null) {
			Debug.LogError("Error loading prefab, path = [" + path + "]");
		}
		return prefab;
	}
}

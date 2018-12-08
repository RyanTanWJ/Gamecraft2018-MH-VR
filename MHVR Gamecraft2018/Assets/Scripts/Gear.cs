using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockType = Block.BlockType;

public class Gear : MonoBehaviour
{

	[SerializeField]
	private float _size;

	[SerializeField]
	List<Sprite> HighlightedSprites;
	[SerializeField]
	Sprite RegularSprite;

	/// <summary>
	/// If the gear is in phase with the main gear
	/// </summary>
	[SerializeField]
	bool inPhase;

	public void ActivateGear(bool player)
	{
		GetComponent<SpriteRenderer>().sprite = HighlightedSprites[player ? 1 : 0];
	}

	public void DeactivateGear()
	{
		GetComponent<SpriteRenderer>().sprite = RegularSprite;
	}

	public float Size
	{
		get { return _size; }
		set { _size = value; }
	}

	public float RotationSpeed
	{
		get { return 10; }
	}

	public void Start()
	{
		CreateBlock();
	}

	public void Rotate(float masterSize, float degrees)
	{
		if (inPhase)
		{
			transform.Rotate(0, 0, degrees * (masterSize / _size));
		}
		else
		{
			transform.Rotate(0, 0, -degrees * (masterSize / _size));
		}
	}

	public void CreateBlock()
	{
		Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
		Instantiate(PrefabManager.blockPrefab[(BlockType)Random.Range(0, 7)], transform.position, spawnRotation, transform);
	}
}

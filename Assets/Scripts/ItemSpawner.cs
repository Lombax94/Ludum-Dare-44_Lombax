using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ItemSpawner : MonoBehaviour {

	public Sprite _ItemsSpriteSheet;
	public SpriteAtlas test;

	Sprite[] _AllTheItems;
	public GameObject _ItemPrefab;
	GameObject _SpawnedObject;

    // Start is called before the first frame update
    void Start() {
	}




	public GameObject GetItem(GameObject objectAsking) {
		_SpawnedObject = (GameObject)Instantiate(_ItemPrefab);
		_SpawnedObject.GetComponent<ItemInfo>().SetInfo(Random.Range(5,40));
		_SpawnedObject.GetComponent<SpriteRenderer>().sprite = test.GetSprite("AllItems_" + Random.Range(0, 33));

		return _SpawnedObject;
	}





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarManagement : MonoBehaviour {

	public bool CustomerComing = false;
	public ItemInfo _BiddingItem;

	ItemSpawner _ItemSpawner;
	UpdateNumberDisplays _NumberUpdate;

	// Start is called before the first frame update
	void Start() {

		GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y - 0.14f) * -10);//Setting SortingOrders
		transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y - 0.14f) * -10) + 1;
		transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y - 0.14f) * -10) + 1;
		transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y - 0.14f) * -10) + 1;

		_ItemSpawner = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ItemSpawner>();
		_NumberUpdate = GetComponent<UpdateNumberDisplays>();

		GetNewItem();


	}

	public void GetNewItem() {

		if(_BiddingItem != null) {
			Destroy(_BiddingItem.gameObject);
		}

		_BiddingItem = _ItemSpawner.GetItem(gameObject).GetComponent<ItemInfo>();
		_BiddingItem.transform.parent = transform;
		_BiddingItem.transform.localPosition = new Vector2(0.015f, 0.08f);
		_BiddingItem.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y - 0.14f) * -10) + 1;

		GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<DisplayManager>().Payback(_BiddingItem.GetCost() / 2);
		_NumberUpdate.NewValue(_BiddingItem.GetCost());
	}

	// Update is called once per frame
	void Update() {

		

	}

}

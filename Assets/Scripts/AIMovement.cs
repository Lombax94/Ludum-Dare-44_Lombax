using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

	Transform _ParentDisplayAltar;
	AltarManagement TargetAltar;

	public List<Transform> WalkPath = new List<Transform>();

	public float speed = 1;


	int walkindex = 0;
	bool reachedEndpoint = false;

	SpriteRenderer body;
	SpriteRenderer head;
	SpriteRenderer bubble;


	float _Price = 0;
	bool GoInnOrOut = true;

	// Start is called before the first frame update
	void Start() {

		_ParentDisplayAltar = GameObject.FindGameObjectWithTag("Displays").transform;
		body = transform.GetChild(0).GetComponent<SpriteRenderer>();
		head = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
		bubble = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();

	}

	public void SetTargetAltar(AltarManagement targetAltar, int pathID) {
		TargetAltar = targetAltar;
		TargetAltar.CustomerComing = true;
		HardCodedPath(pathID);
	}

	bool OpenDoorBeforeExit = false;
	// Update is called once per frame
	void Update() {

		if (reachedEndpoint == false) {
			if (walkindex == WalkPath.Count - 1) {
				transform.position = Vector2.MoveTowards(transform.position, WalkPath[walkindex].transform.position , speed * Time.deltaTime);
				if (GoInnOrOut == true) {
					if (Vector3.Distance(transform.position, WalkPath[walkindex].transform.position) <= 0.02f) {
						reachedEndpoint = true;
						StartBidding();
					}
				} else {
					if (OpenDoorBeforeExit == false) {
						if (Vector3.Distance(transform.position, WalkPath[walkindex].transform.position) <= 0.5f) {
							OpenDoorBeforeExit = true;
							GameObject.FindGameObjectWithTag("Door").GetComponent<OpenClose>().OpenDoor();
						}
					} else {
						if (Vector3.Distance(transform.position, WalkPath[walkindex].transform.position) <= 0.02f) {
							Destroy(gameObject);
						}
					}
				}
			} else {
				transform.position = Vector2.MoveTowards(transform.position, WalkPath[walkindex].transform.position, speed * Time.deltaTime);
				if (Vector3.Distance(transform.position, WalkPath[walkindex].transform.position) <= 0.02f) {
					walkindex++;
				}
			}

			body.sortingOrder = (int)(transform.position.y * -10);
			head.sortingOrder = (int)(transform.position.y * -10);

		}
	}


	void HardCodedPath(int altarNumber) {//1 hour left, this is all i can do. :D
		WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(0).transform);

		if (altarNumber == 0 || altarNumber == 1 || altarNumber == 2) {
			WalkPath.Add(TargetAltar.transform);
		}else if(altarNumber == 3) {
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(1).transform);
			WalkPath.Add(TargetAltar.transform);
		}else if (altarNumber == 4) {
			if (Random.Range(0, 1) == 0){
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(1).transform);
			} else {
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(2).transform);
			}
			WalkPath.Add(TargetAltar.transform);
		} else if (altarNumber == 5) {
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(2).transform);
			WalkPath.Add(TargetAltar.transform);
		} else if (altarNumber == 6) {
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(1).transform);
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(3).transform);
			WalkPath.Add(TargetAltar.transform);
		} else if (altarNumber == 7) {
			if (Random.Range(0, 1) == 0) {
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(1).transform);
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(3).transform);
			} else {
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(2).transform);
				WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(4).transform);
			}
			WalkPath.Add(TargetAltar.transform);
		} else if (altarNumber == 8) {
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(2).transform);
			WalkPath.Add(GameObject.FindGameObjectWithTag("MidwayPoints").transform.GetChild(4).transform);
			WalkPath.Add(TargetAltar.transform);
		}

	}


	void StartBidding() {

		transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
		transform.GetChild(0).GetComponent<Animator>().SetBool("Idle", true);

		SetBuyerBiddingPrice();

	}

	
	void SetBuyerBiddingPrice() {

		_Price = TargetAltar._BiddingItem.GetCost() * (Random.Range(25, 150) / 100f);
		bubble.transform.GetComponent<UpdateNumberDisplays>().NewValue((int)_Price);

	}

	public void GettingPlayerInput(bool purchaseOrWalk) {

		TargetAltar.CustomerComing = false;
		transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
		transform.GetChild(0).GetComponent<Animator>().SetBool("Idle", false);

		if (purchaseOrWalk == true) {

			TargetAltar.GetNewItem();
			GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<DisplayManager>().RecievePurchase((int)_Price);
			GameObject.FindGameObjectWithTag("Door").GetComponent<EnemySpawner>().BoughtAnItem();

			WalkPath.Reverse();
			walkindex = 0;
			reachedEndpoint = false;
			GoInnOrOut = false;

		} else {

			GameObject.FindGameObjectWithTag("Door").GetComponent<EnemySpawner>().WalkedOut();

			WalkPath.Reverse();
			walkindex = 0;
			reachedEndpoint = false;
			GoInnOrOut = false;

		}

	}


	

}

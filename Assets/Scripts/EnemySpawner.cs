using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	AltarManagement[] _Altars;
	public GameObject Enemy;

	float SpawnIncrements = 5;

	float TimeBetweenEachIncrease = 4f;
	float SpawnRateTimer = 0;
	float TimeIncrease = 2;


	int MaxAltarsAvailable = 9;
	int AltarsAvailable = 9;
	int _MaxSpawned = 0;
	float _TimeCounter = 0;
	GameObject target;




	// Start is called before the first frame update
	void Start() {
		_Altars = GameObject.FindGameObjectWithTag("Displays").GetComponentsInChildren<AltarManagement>();
	}

	// Update is called once per frame
	void Update() {

		if (SpawnRateTimer >= TimeBetweenEachIncrease) {
			SpawnRateTimer = 0;
			TimeBetweenEachIncrease += TimeIncrease;

			if (TimeIncrease > 0)
				_MaxSpawned++;
			else
				_MaxSpawned--;

			if (TimeBetweenEachIncrease == 4 + (TimeIncrease * 9)) {
				SpawnRateTimer = -30;
				TimeIncrease *= -1;
			} else if (TimeBetweenEachIncrease == 4) {
				SpawnRateTimer = -15;
				TimeIncrease *= -1;
			}
		} else {
			SpawnRateTimer += Time.deltaTime;
		}


		if (MaxAltarsAvailable - AltarsAvailable < _MaxSpawned) {

			_TimeCounter += Time.deltaTime;

			if (_TimeCounter >= SpawnIncrements) {
				if (SpawnObjectIfPossible() == true) {
					GameObject.FindGameObjectWithTag("Door").GetComponent<OpenClose>().OpenDoor();
					AltarsAvailable--;
					_TimeCounter = 0;
					SpawnIncrements = 5 - (int)(_MaxSpawned / 2);
				}

				_TimeCounter = 0;
			}
		}
	}

	public void BoughtAnItem() {
		AltarsAvailable++;
	}

	public void WalkedOut() {
		AltarsAvailable++;
	}

	bool SpawnObjectIfPossible() {
		for(int i = 0; i < _Altars.Length; i++) {
			if(_Altars[i].CustomerComing == false && _Altars[i]._BiddingItem != null) {
				return FindRngAltar(i);
			}
		}
		return false;
	}

	int index = 0;
	bool FindRngAltar(int foundbefore) {
		for (int i = 0; i < 20; i++) {//20 Is Maximum Attempts For RNG
			index = Random.Range(0, 8);
			if (_Altars[index].CustomerComing == false && _Altars[index]._BiddingItem != null) {
				target = Instantiate(Enemy, Vector3.up * 1.45f, Quaternion.identity);
				target.GetComponent<AIMovement>().SetTargetAltar(_Altars[index], index);
				return true;
			}
		}

		target = Instantiate(Enemy, Vector3.up * 1.45f, Quaternion.identity);
		target.GetComponent<AIMovement>().SetTargetAltar(_Altars[foundbefore], foundbefore);
		return true;
	}


	
}

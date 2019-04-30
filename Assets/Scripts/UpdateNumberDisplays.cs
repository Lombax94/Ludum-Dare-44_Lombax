using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNumberDisplays : MonoBehaviour {


	int _CurrentAltarValue = 0;
	int _SavedValue = 0;
	int BiggerThenNumber = 0;

	DisplayNumbers _TheSprites;
	SpriteRenderer[] _ChildRenderers;

	// Start is called before the first frame update
	void Awake() {
		_ChildRenderers = transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>();//TODO Placement Of GameObjects Is Important

		BiggerThenNumber = 1;
		for (int i = 0; i <= _ChildRenderers.Length - 1; i++) {
			BiggerThenNumber *= 10;
		}
		BiggerThenNumber -= 1;

		_TheSprites = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DisplayNumbers>();

		AddValue(0);

	}
	

	public void AddValue(int theNumbers) {

		_CurrentAltarValue += theNumbers;
		_SavedValue = _CurrentAltarValue;

		SetNumbers();

	}

	public void NewValue(int theNumbers) {

		_CurrentAltarValue = theNumbers;
		_SavedValue = _CurrentAltarValue;

		SetNumbers();

	}

	public void RemoveValue(int theNumbers) {

		_CurrentAltarValue -= theNumbers;
		_SavedValue = _CurrentAltarValue;

		SetNumbers();

	}

	public void SetNumbers() {//Setting The Number Placed In _SavedValue

		if (_SavedValue <= BiggerThenNumber && _SavedValue >= 0) {

			for (int i = _ChildRenderers.Length - 1; i >= 0; i--) {//Changing The Sprite To The Corresponding Int Value.
				_ChildRenderers[i].sprite = _TheSprites.numbertest[(_SavedValue % 10)];
				_SavedValue /= 10;

				if (_SavedValue <= 0) {//If In Dont Fill All Sprites, Do A Clear To Set All Sprites To null After The Last Number Placed.
					if (i > 0) {
						for (int j = i - 1; j >= 0; j--) {
							_ChildRenderers[j].sprite = null;
						}
					}
					return; //If It Reaches Here, Then The Iteration Is Complete.
				}

			}

		} else {

			if (_SavedValue < 0) {

				for (int i = 0; i < _ChildRenderers.Length - 1; i++) {//Giving The Sprite The Value 999 Cuz It Went Above Max Amount Of Value Showing.
					_ChildRenderers[i].sprite = null;
				}
				_ChildRenderers[_ChildRenderers.Length - 1].sprite = _TheSprites.numbertest[0];

			} else {

				for (int i = 0; i <= _ChildRenderers.Length - 1; i++) {//Giving The Sprite The Value 999 Cuz It Went Above Max Amount Of Value Showing.
					_ChildRenderers[i].sprite = _TheSprites.numbertest[9];
				}
			}

		}

	}

}

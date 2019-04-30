using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour {

	public int StartScore = 0;
	int _Score = 0;



	private void Start() {
		RecievePurchase(1000);
	}

	public void RecievePurchase(int gain) {
		_Score += gain;
		transform.GetComponent<UpdateNumberDisplays>().AddValue(gain);

		GetComponent<Animator>().SetBool("Gain", true);

	}

	public void Payback(int loss) {
		_Score -= loss;
		transform.GetComponent<UpdateNumberDisplays>().RemoveValue(loss);

		GetComponent<Animator>().SetBool("Lose", true);

	}

	[System.Obsolete]
	void Update() {
		
		if(_Score <= 0) {
			Application.LoadLevel(1);
		}


	}

}

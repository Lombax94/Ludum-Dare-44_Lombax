using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDrinking : MonoBehaviour {

	public void SetGainFalse() {
		GetComponent<Animator>().SetBool("Gain", false);
	}

	public void SetLoseFalse() {
		GetComponent<Animator>().SetBool("Lose", false);
	}

}

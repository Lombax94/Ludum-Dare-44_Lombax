using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTransaction : MonoBehaviour {

	public bool AcceptOrDeny = false;//True == Accept, Deny == False

	private void OnMouseDown() {
		transform.parent.parent.parent.GetComponent<AIMovement>().GettingPlayerInput(AcceptOrDeny);
	}

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour {

	public Sprite Open;
	public Sprite Close;
	public AudioSource sound;
	public SpriteRenderer TheRenderer;


	public void OpenDoor() {

		if (CurrentOpenTime >= OpenTime) {
			TheRenderer.sprite = Open;
			sound.Play();
		}

		Checker = true;
		CurrentOpenTime = 0;

	}
	

	bool Checker = false;
	float OpenTime = 1.5f;
	float CurrentOpenTime = 10;
	void Update() {
		
		if(Checker == true) {

			CurrentOpenTime += Time.deltaTime;

			if (CurrentOpenTime >= OpenTime) {
				Checker = false;
				TheRenderer.sprite = Close;
				sound.Play();
			}
		}

	}

}

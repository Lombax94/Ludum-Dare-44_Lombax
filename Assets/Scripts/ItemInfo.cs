using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour {

	//The Price Generaly Is What Ppl Feel That The Specific Item Is Worth, If No One Care About Gold, And A Golden Tooth Appear, It Might Never Sell Unless You Take A Loss.
	//So Iteration Two Would Be Make This Kind Of Behaviour Where, We Might Have Different Places That The Shops Appear And Naturaly Sertain Items Will Be Needed More And The Profit Will Rise.
	//If A Place Have Its Own Water Factory, Then Water Will Be Less Worth Cus PPl Alrdy Have Enough Of It.

	//And Also Make PPl Coming Reflect Their Status. Some Well Dressed, Some Poor. And So On. Ritch PPl Might Narutaly Pay More, Like 75%-125%

	int Rarity = 0;//The Rarity Of The Item, Will Naturaly Increase The Price If The Item Is Wanted.
	int Cost = 0;
	int Condition = 0;//If The Displayed Item Is In Perfect Condition, The Value Will Increase.

	public void SetInfo(int ItemCost) {
		Rarity = Random.Range(0,100);
		Condition = Random.Range(50, 150);

		if (Rarity < 50) {//Common
			Rarity = 1;
		} else if (Rarity < 80) {//Normal
			Rarity = 2;
		} else if (Rarity < 95) {//Rare
			Rarity = 3;
		} else {//Epic
			Rarity = 4;
		}

		Cost = (int)(ItemCost * Rarity * (Condition / 100f));//TODO Make A Condition Visible On Items, Make Cracks Or Tears.
		Cost = Cost * 2;//First Part Is The Cost Of The Item, NoWhere Else To Have It Atm.
	}


	public int GetCost() {
		return Cost;
	}

	public int GetRarity() {
		return Rarity;
	}

	public int GetCondition() {
		return Condition;
	}

}

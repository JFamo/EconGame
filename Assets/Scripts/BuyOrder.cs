using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOrder : MonoBehaviour {

	private int goodID;
	private int price;

	public Transaction(int goodID, int price){
		this.goodID = goodID;
		this.price = price;
	}

}

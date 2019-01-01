using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	Joshua Famous 5:06 AM
 * 	Transaction will store buy orders, sell orders, and complete transactions with a good and price
 *
 */

public class Transaction : MonoBehaviour {

	private int goodID;
	private int price;

	public Transaction(int goodID, int price){
		this.goodID = goodID;
		this.price = price;
	}

	public int getGoodID(){
		return goodID;
	}

	public int getPrice(){
		return price;
	}

}

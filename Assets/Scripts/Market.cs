using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Joshua Famous, 4:54 AM
 * Controls and fulfills buy/sell orders, saving data points to create Supply and Demand graphs
 * 
 */

public class Market : MonoBehaviour {

	public static List<Transaction> buyOrders;
	public static List<Transaction> sellOrders;
	public static List<Transaction> completeTransactions;

	void Start(){
		buyOrders = new List<Transaction> ();
		sellOrders = new List<Transaction> ();
	}

	void Update () {
		if (buyOrders.Count > 0 && sellOrders.Count > 0) {
			MatchBuyOrders ();
		}
	}

	public static void PlaceBuyOrder(Transaction buyOrder){
		buyOrders.Add (buyOrder);
		Debug.Log ("Got Buy Order for " + buyOrder.getGoodID () + " at " + buyOrder.getPrice ());
	}

	public static void PlaceSellOrder(Transaction sellOrder){
		sellOrders.Add (sellOrder);
	}

	public static void MatchBuyOrders(){
		for(int buyIndex=0; buyIndex < buyOrders.Count; buyIndex++){
			for(int sellIndex=0; sellIndex < sellOrders.Count; sellIndex++){
				if(buyOrders[buyIndex].getGoodID() == sellOrders[sellIndex].getGoodID()){
					if(buyOrders[buyIndex].getPrice() >= sellOrders[sellIndex].getPrice()){
						Transact (buyIndex, sellIndex);
					}
				}
			}
		}
	}

	public static void Transact(int buyIndex, int sellIndex){

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Joshua Famous, 4:54 AM
 * Controls and fulfills buy/sell orders, saving data points to create Supply and Demand graphs
 * 
 */

public class Market : MonoBehaviour {

	public List<Transaction> buyOrders;
	public List<Transaction> sellOrders;
	public List<Transaction> completeTransactions;

	void Update () {
		MatchBuyOrders ();
	}

	public void MatchBuyOrders(){
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

	public void Transact(int buyIndex, int sellIndex){

	}

}

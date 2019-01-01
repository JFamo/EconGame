using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour {

	// There are four stages to each "tick"
	// 		Decay - each person consumes some good
	// 		Order - each person decides to buy or not to buy some whack shit
	// 		analysis - Measure the market forces, see what people are doing
	// 		Fulfill - The market matches orders and fills as necessary.
	// I need to write functions to handle Decay and Order
	// Also, the individual needs to be ready for the analysis phase
	// We'll call this the "crisis" phase, in which the individual decides
	// If the shit has hit the fan. "Is Carlos Nervous?"
	// Crisis will be "Hidden", as in Decay will transition to it automatically.
	// Market and other classes need not be concerned.
	// We'll also need an initialization, where the individual is created.

	// TL;DR
	// Init - Create a new individual
	// Decay/Crisis - Eat goods - Am I Happy?
	// Order - Place buy and sell orders

	// SETTINGS ------------------------------------------------------------

	// How lazy am I?
	public double lazyness = 5;

	// How many goods are there?
	public static int number_of_goods = 6;

	//GLOBAL ---------------------------------------------------------------

	//Store BUV's of all 6 products
	public int[] baseUtilityValues = new int[number_of_goods];

	// STATE    ------------------------------------------------------------

	// there are 6 possible goods. Map ID -> Quantity
	public int[] inventory = new int[number_of_goods];

	// How much gold do I have?
	public int gold = 0;

	// How happy am I? This is updated by Crisis, which happens with Decay
	public double happy;

	// FUNCTIONS

	public void Init(){
		for(int i=0; i<number_of_goods; i++){
			inventory[i] = 0;
		}
		lazyness = Random.Range (1, 10);

		//Start my action cycle
		InvokeRepeating("DoTick", 2.0f,3.0f);
	}

	void DoTick(){
		Decay ();
		Order ();
	}

	public void Decay(){
		int goodsConsumed = 0;
		for(int i=0; i<6; i++){
			if(inventory[i] >= 1){
				inventory[i] -= 1;
				goodsConsumed++;
			}
		}
		Crisis(goodsConsumed);
	}

	public void Crisis(int eaten){
		// How happy I am, for now, to keep it simple, is how much I've eated.
		happy = eaten;
	}

	// This function expects a way to
	public void Order(){
		int item_to_buy = -1;
		int margin_if_bought = 0;
		int item_to_sell = -1;
		int margin_maintained = int.MaxValue;

		// Determine to buy or sell each good
		for(int i=0; i<6; i++){
			int weHave = inventory[i];
			// Buy the item that we want the most
			int desire_to_buy = CalculateMarginalUtility(i);
			if(desire_to_buy > margin_if_bought){
				margin_if_bought = desire_to_buy;
				item_to_buy = i;
			}
			// Sell the item that we want the least
			int gain_by_selling = CalculateMarginalUtility(i);
			if(gain_by_selling < margin_maintained){
				margin_maintained = gain_by_selling;
				item_to_sell = i;
			}
		}

		// Do we actually want to buy this?
		if(item_to_buy != -1 && margin_if_bought > lazyness){
			//Assume that we would like to place a buy order even if we are too poor to afford this MU
			if(gold > margin_if_bought){
				Market.PlaceBuyOrder(new Transaction(item_to_buy,margin_if_bought));
			}
			else if(gold > 0){
				Market.PlaceBuyOrder(new Transaction(item_to_buy,gold));
			}
		}

		// Do we actually want to sell this?
		if(item_to_sell != -1 && margin_maintained < lazyness){
			Market.PlaceSellOrder(new Transaction(item_to_sell,margin_maintained));
		}

		// We expect the market to do something like person.inventory[item]++ or -- if the order is filled.
		// If the order is filled, inventory will be changed before the next decay.
		// If the order is not filled, Decay will occur, desire to buy increases, we offer a higher price.
		// It's in the market's hands now.

	}

	//Calculate the MU derived (my value) for a given good
	public int CalculateMarginalUtility(int goodIndex){
		double baseUtilityValue = FindGoodBUV (goodIndex);
		return (int)(baseUtilityValue - (Random.Range(0,200)/100.0) * (inventory[goodIndex]+1));
	}	

	public double FindGoodBUV(int goodIndex){
		for (int i = 0; i < 6; i++) {
			if (Town.goodList [i].goodID == goodIndex) {
				return Town.goodList[i].baseUtilityValue;
			}
		}
		return -1;
	}
		
	public Individual(){
		Init();
	}
}

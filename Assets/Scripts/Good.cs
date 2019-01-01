using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Joel Seidel
 * Good object
 * Ruined by Joshua Famous
 */

	public class Good : MonoBehaviour
    {
        public string name;
        public double baseUtilityValue;
		public int goodID;
        
		public Good(string name, double baseUtilityValue, int goodID)
        {
            this.name = name;
            this.baseUtilityValue = baseUtilityValue;
			this.goodID = goodID;
        }
    }

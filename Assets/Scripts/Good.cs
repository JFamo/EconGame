using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * Author: Joel Seidel
 * Good object
 */
namespace Assets.Scripts
{
    public class Good
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
}

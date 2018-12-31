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
        
        public Good(string name, double baseUtilityValue)
        {
            this.name = name;
            this.baseUtilityValue = baseUtilityValue;
        }
    }
}

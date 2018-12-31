using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Joel Seidel, Joshua Famous
 * Controls town dyanmics
 */

public class Town : MonoBehaviour {

    public string townName;
    public Good product;

    void Start () {
		
	}
	
	void Update () {
		
	}
    
    /**
     * Joel Seidel
     * Initialize the town product
     */
    public void init(string townName)
    {
        this.townName = townName;
        //Generate the random number which is the seed for the item to be created
        int productSeed = Random.Range(0, 3);
        string[] productSelections;
        double[] productsUtilities;
        //Determine the town product and product utility based on the color of the town
        switch (townName)
        {
            case "Red":
                productSelections = new string[] { "apples", "fire trucks", "red solo cups" };
                productsUtilities = new double[] { 50, 10, 5 };
                break;
            case "Blue":
                productSelections = new string[] { "fish", "blueberries", "water" };
                productsUtilities = new double[] { 60, 75, 95 };
                break;
            case "Green":
                productSelections = new string[] { "grapes", "trees", "dollar bills" };
                productsUtilities = new double[] { 45, 90, 15 };
                break;
            case "Yellow":
                productSelections = new string[] { "bananas", "rubber ducks", "corn" };
                productsUtilities = new double[] { 65, 90, 30 };
                break;
            case "Black":
                productSelections = new string[] { "olives", "tires", "oil" };
                productsUtilities = new double[] { 30, 50, 85 };
                break;
            case "Beige":
                productSelections = new string[] { "corduroy pants", "curtains", "copper" };
                productsUtilities = new double[] { 20, 10, 40 };
                break;
            default:
                productSelections = new string[3];
                productsUtilities = new double[3];
                break;
        }
        //Set the towns producing good value
        this.product = new Good(productSelections[productSeed], productsUtilities[productSeed]);
    }
}

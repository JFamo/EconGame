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
    public List<Individual> individuals;
	public static List<Good> goodList;

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
		goodList = new List<Good> ();
        this.townName = townName;
        initProduct();
        initIndividuals();
    }

    private void initProduct()
    {
        //Generate the random number which is the seed for the item to be created
        int productSeed = Random.Range(0, 3);
        string[] productSelections;
        double[] productsUtilities;
		int goodID;
        //Determine the town product and product utility based on the color of the town
        switch (townName)
        {
		case "Red":
			productSelections = new string[] { "apples", "fire trucks", "red solo cups" };
			productsUtilities = new double[] { 50, 10, 5 };
			goodID = 0;
            break;
		case "Blue":
			productSelections = new string[] { "fish", "blueberries", "water" };
			productsUtilities = new double[] { 60, 20, 95 };
			goodID = 1;
                break;
		case "Green":
			productSelections = new string[] { "grapes", "trees", "dollar bills" };
			productsUtilities = new double[] { 45, 90, 15 };
			goodID = 2;
                break;
		case "Yellow":
			productSelections = new string[] { "bananas", "rubber ducks", "corn" };
			productsUtilities = new double[] { 65, 90, 30 };
			goodID = 3;
                break;
		case "Black":
			productSelections = new string[] { "olives", "tires", "oil" };
			productsUtilities = new double[] { 30, 50, 85 };
			goodID = 4;
                break;
		case "Beige":
			productSelections = new string[] { "corduroy pants", "curtains", "copper" };
			productsUtilities = new double[] { 20, 10, 70 };
			goodID = 5;
                break;
		default:
			productSelections = new string[3];
			productsUtilities = new double[3];
			goodID = -1;
                break;
        }
        //Set the towns producing good value
        this.product = new Good(productSelections[productSeed], productsUtilities[productSeed], goodID);
		goodList.Add (product);
        Debug.Log("Created town : " + townName + " which produces: " + product.name + " with a utility value of: " + product.baseUtilityValue);
    }
    /**
     * Joel Seidel
     * Create the individuals for this town
     */
    private void initIndividuals()
    {
        //Init the individuals list
        individuals = new List<Individual>();
        for(int i = 0; i < 25; i++)
        {
            //Add the created individual to the town listing
            individuals.Add(new Individual());
            Debug.Log("Created a new individual. I am number: " + i);
        }
    }
}

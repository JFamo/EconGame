using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Joel Seidel
 * Initializes the game mechanics
 */
public class Controller : MonoBehaviour {
    private List<GameObject> towns;
	void Start () {
        initTowns();
	}

    /**
     * Joel Seidel
     * Initialize the town objects on scene start
     */
    void initTowns()
    {
        //Town colors array
        string[] colors = { "Red", "Blue", "Green", "Yellow", "Black", "Beige" };
        //Create 6 towns
        for (int i = 0; i < 6; i++)
        {
            //Define the empty game object to house the town monobehaviour script
            GameObject thisTownObj = GameObject.Find(colors[i] + "Town");
            //Define the town mono object
            Town thisTown = thisTownObj.AddComponent<Town>();
            //Initialize the town
            thisTown.init(colors[i]);
        }
    }

    /**
     * Joel Seidel
     * Lookup function of product util from product name
     */
    public double getProductUtil(string productName)
    {
        //Lookup swithc for the utility value
        switch (productName)
        {
            case "apples":
                return 50;
            case "fire trucks":
                return 10;
            case "red solo cups":
                return 5;
            case "fish":
                return 60;
            case "blueberries":
                return 20;
            case "water":
                return 95;
            case "grapes":
                return 45;
            case "trees":
                return 90;
            case "dollar bills":
                return 15;
            case "bananas":
                return 65;
            case "rubber ducks":
                return 90;
            case "corn":
                return 15;
            case "olives":
                return 30;
            case "tires":
                return 50;
            case "oil":
                return 85;
            case "corduroy pants":
                return 20;
            case "curtains":
                return 10;
            case "copper":
                return 70;
            default:
                return -1;
        }
    }
}

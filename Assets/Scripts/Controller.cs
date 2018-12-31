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
}

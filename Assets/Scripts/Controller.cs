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
        string[] colors = { "red", "blue", "green", "yellow", "black", "beige" };
        for (int i = 0; i < 6; i++)
        {
            GameObject thisTownObj = Instantiate(new GameObject("town-name: " + colors[i]));
            Town thisTown = thisTownObj.AddComponent<Town>();
            thisTown.init(colors[i]);
        }
    }
}

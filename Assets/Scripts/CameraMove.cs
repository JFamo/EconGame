using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject camera;
	
	// Update is called once per frame
	void Update () {

		//Check for camera rotation
		if (Input.GetKey(KeyCode.D))
		{
			camera.transform.Rotate(new Vector3(0,15,0) * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			camera.transform.Rotate(new Vector3(0,-15,0) * Time.deltaTime);
		}
		//Check for town and market clicking
		if( Input.GetMouseButtonDown(0) )
	     {
	         Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
	         RaycastHit hit;
	         
	         if( Physics.Raycast( ray, out hit, 100 ) )
	         {
	             Debug.Log( hit.transform.gameObject.name );
	         }
	     }
	}
}

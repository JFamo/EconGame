using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject camera, currentTown;
	public Camera myCam;
	public Camera currentTownCam;
	public Vector3 initialPosition;
	public Quaternion initialRotation;
	public bool cameraMoveEnabled, backEnabled;
	public float speed;

	void Start(){
		initialPosition = myCam.gameObject.transform.position;
		initialRotation = myCam.gameObject.transform.rotation;
		currentTownCam = null;
		currentTown = null;
		cameraMoveEnabled = false;
		backEnabled = false;
		speed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {

		//Check for camera rotation
		if (Input.GetKey(KeyCode.D) && myCam.enabled && !backEnabled && !cameraMoveEnabled)
		{
			camera.transform.Rotate(new Vector3(0,15,0) * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A) && myCam.enabled && !backEnabled && !cameraMoveEnabled)
		{
			camera.transform.Rotate(new Vector3(0,-15,0) * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Escape) && !myCam.enabled && !backEnabled && !cameraMoveEnabled)
		{
			myCam.enabled = true;
        	currentTownCam.enabled = false;
			backEnabled = true;
		}
		//Check for town and market clicking
		if( Input.GetMouseButtonDown(0) )
	     {
	         Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
	         RaycastHit hit;
	         
	         if( Physics.Raycast( ray, out hit, 100 ) )
	         {
	         	if(!backEnabled){
		         	currentTown = hit.transform.gameObject;
		            currentTownCam = hit.transform.gameObject.GetComponentInChildren<Camera>();
		            cameraMoveEnabled = true;
	        	}
	         }
	     }
	    if(cameraMoveEnabled){
	    	myCam.transform.position = Vector3.Lerp(myCam.transform.position, currentTownCam.transform.position, speed * Time.deltaTime);
        	myCam.transform.rotation = Quaternion.Lerp(myCam.transform.rotation, currentTownCam.transform.rotation, speed * Time.deltaTime);
        	if(Vector3.Distance(myCam.transform.position, currentTownCam.transform.position) < 0.1f){
        		currentTownCam.enabled = true;
        		myCam.enabled = false;
        		cameraMoveEnabled = false;
        	}
	    }
	    if(backEnabled){
	    	myCam.transform.position = Vector3.Lerp(myCam.transform.position, initialPosition, speed * Time.deltaTime);
        	myCam.transform.rotation = Quaternion.Lerp(myCam.transform.rotation, initialRotation, speed * Time.deltaTime);
        	if(Vector3.Distance(myCam.transform.position, initialPosition) < 0.1f){
        		myCam.gameObject.transform.position = initialPosition;
        		myCam.gameObject.transform.rotation = initialRotation;
        		backEnabled = false;
        	}
	    }
	}
}

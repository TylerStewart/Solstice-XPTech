using UnityEngine;
using System.Collections;

public class HandTool : MonoBehaviour {

	GameObject currentObject;
	public GameObject studioWorld;
	// Use this for initialization
	TrackedControllerTarget targetProvider;
	GameObject parentObj;
	void OnEnable () {
		SteamVR_InputManager.OnCursorHandTriggerPressDown += InputDown;
		SteamVR_InputManager.OnCursorHandTriggerPressUp += InputUp;
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InputDown(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}

	void InputUp(){
		releaseObject();//Unparent object from controller
	}
	void pickUpObject(){
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="WorldObj"){
			targetProvider.targetObj.transform.parent = targetProvider.transform;
			currentObject = targetProvider.targetObj;
		}
	}

	void releaseObject(){
		if(currentObject){
			currentObject.transform.parent = studioWorld.transform;
			currentObject=null;
		}
	}
}

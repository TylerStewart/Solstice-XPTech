using UnityEngine;
using System.Collections;

public class HandTool : MonoBehaviour {

	GameObject currentObject;
	public GameObject studioWorld;
	// Use this for initialization
	TrackedControllerTarget targetProvider;
	GameObject parentObj;
	void OnEnable () {
		SteamVR_InputManager.OnCursorHandTriggerPressDown += CursorTriggerPressDown;
		SteamVR_InputManager.OnCursorHandTriggerPressUp += CursorTriggerPressUp;
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CursorTriggerPressDown(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}

	void CursorTriggerPressUp(){
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

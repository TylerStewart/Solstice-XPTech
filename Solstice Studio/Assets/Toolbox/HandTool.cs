using UnityEngine;
using System.Collections;

public class HandTool : Tool {

	GameObject currentObject;
	// Use this for initialization
	GameObject parentObj;
	
	protected override void Press(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}

	protected override void Release(){
		releaseObject();//Unparent object from controller
	}
	void pickUpObject(){
		print(targetProvider.targetObj);
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="WorldObj"){
			targetProvider.targetObj.transform.parent = targetProviderTransform;
			currentObject = targetProvider.targetObj;
		}
	}

	void releaseObject(){
		if(currentObject){
			currentObject.transform.parent = StudioWorld.transform;
			currentObject=null;
		}
	}
}

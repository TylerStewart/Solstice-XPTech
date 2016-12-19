using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTool : Tool {
	GameObject currentObject;
	Quaternion startRotation;
	Vector3 offset;
	// Use this for initialization
	protected override void Init(){
		base.Init();
		print(targetProvider.ToString());
	}

	protected override void Press(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}
	protected override void Release(){
		releaseObject();//Unparent old object from controller
	}
	protected override void Hold(){

	}

	void Update(){
		if(currentObject){
			currentObject.transform.rotation = startRotation;
		}
	}

	void pickUpObject(){
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="WorldObj"){
			//offset = targetProvider.targetObj.transform.position - targetProviderTransform.position;
			startRotation = targetProvider.targetObj.transform.rotation;
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

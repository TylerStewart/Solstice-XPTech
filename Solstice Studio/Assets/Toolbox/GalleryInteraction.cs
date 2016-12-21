using UnityEngine;
using System.Collections;

public class GalleryInteraction : Tool {

	// Use this for initialization
	GameObject currentObject;
	Vector3 scale;
	Vector3 rotation;
	
	// Update is called once per frame
	void Update () {
		if(currentObject)
			currentObject.transform.eulerAngles = new Vector3 (rotation.x,rotation.y,rotation.z);
	}

	protected override void Press(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}

	protected override void Release(){
		releaseObject();//Unparent object from controller
	}

	void pickUpObject(){
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="GalleryObj"){
			GalleryItem item = targetProvider.targetObj.GetComponent<GalleryItem>();
			GameObject go = GameObject.Instantiate(item.objPrefab);
			go.transform.position = targetProvider.HitInfo.transform.position;
			go.transform.parent = targetProviderTransform;
			go.transform.localScale = item.originalScale*StudioWorld.transform.localScale.x;
			currentObject = go;
			scale = item.originalScale;
			rotation = item.originalRotation;
		}
	}

	void releaseObject(){
		if(currentObject){
			currentObject.transform.parent = StudioWorld.transform;
			currentObject.transform.localScale = scale;
			currentObject.tag = "WorldObj";
			currentObject=null;
		}
	}
}

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
			currentObject.transform.rotation = Quaternion.identity;
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
			GameObject parent = new GameObject(go.name + "ParentObject");
       
			parent.transform.position = targetProvider.HitInfo.transform.position;
			parent.transform.parent = targetProviderTransform;
			parent.transform.rotation = Quaternion.identity;
			go.transform.parent = parent.transform;
			go.transform.localPosition = Vector3.zero;
			parent.transform.localScale = item.originalScale*StudioWorld.transform.localScale.x;
			Rigidbody rb = parent.AddComponent<Rigidbody>();
			rb.useGravity = false;
			rb.isKinematic = true;
			currentObject = parent;
			scale = item.originalScale;
			rotation = item.originalRotation;
		}
	}

	void releaseObject(){
		if(currentObject){
			currentObject.transform.parent = StudioWorld.transform;
			currentObject.transform.localRotation = Quaternion.Euler(0,0,0);
			currentObject.transform.localScale = scale;
			currentObject.tag = "WorldObj";
			currentObject=null;
		}
	}
}

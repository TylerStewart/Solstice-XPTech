using UnityEngine;
using System.Collections;

public class GalleryInteraction : MonoBehaviour {

	// Use this for initialization
	public GameObject studioWorld;
	TrackedControllerTarget targetProvider;
	GameObject currentObject;
	Vector3 scale;
	Vector3 rotation;

	void OnEnable () {
		SteamVR_InputManager.OnCursorHandTriggerPressDown += CursorTriggerPressDown;
		SteamVR_InputManager.OnCursorHandTriggerPressUp += CursorTriggerPressUp;
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentObject)
			currentObject.transform.eulerAngles = new Vector3 (rotation.x,rotation.y,rotation.z);
	}

	void CursorTriggerPressDown(){
		releaseObject();//Unparent old object from controller
		pickUpObject();//Parent new object to controller
	}

	void CursorTriggerPressUp(){
		releaseObject();//Unparent object from controller
	}

	void pickUpObject(){
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="GalleryObj"){
			GalleryItem item = targetProvider.targetObj.GetComponent<GalleryItem>();
			GameObject go = GameObject.Instantiate(item.objPrefab);
			go.transform.position = targetProvider.hitLocation.transform.position;
			go.transform.parent = targetProvider.transform;
			go.transform.localScale = item.originalScale*studioWorld.transform.localScale.x;
			currentObject = go;
			scale = item.originalScale;
			rotation = item.originalRotation;
		}
	}

	void releaseObject(){
		if(currentObject){
			currentObject.transform.parent = studioWorld.transform;
			currentObject.transform.localScale = scale;
			currentObject.tag = "WorldObj";
			currentObject=null;
		}
	}
}

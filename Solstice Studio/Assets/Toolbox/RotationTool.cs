using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTool : Tool {

	// Use this for initialization
	private GameObject currentObject;
	private Vector3 CurrentWorldRotationOfTargetObject;
	//current amount to rotate by
	public float rotationAmount;
	Vector3 startingPosition, axis, targetProviderToObject, perpVec;
	Quaternion startingRotation;
	float hitDist;
	public bool isRotating;
	
	// Update is called once per frame
	void Update () {
		if(currentObject) { 
			Vector3 offsetLoc = targetProviderTransform.forward * hitDist;
			Vector3 offsetVec = Vector3.Project(offsetLoc - startingPosition, perpVec);
			//Debug.DrawLine(currentObject.transform.position, currentObject.transform.position + offsetVec, Color.red);
			Debug.DrawLine(currentObject.transform.position, currentObject.transform.position + axis*5, Color.red);
			print(offsetVec);
			//float offset = offsetVec.magnitude;
			currentObject.transform.localRotation =  Quaternion.AngleAxis(offsetVec.x*200, axis) * startingRotation ;
		}
	}

	protected override void Press(){
		startRotation();
	}

	protected override void Release(){
		stopRotation();
	}

	void startRotation() 
	{
		if(targetProvider.targetObj && targetProvider.targetObj.tag == "WorldObj"){
			hitDist = targetProvider.HitInfo.distance;
			//GalleryItem item = targetProvider.targetObj.GetComponent<GalleryItem>();
			currentObject = targetProvider.targetObj.gameObject;

			CurrentWorldRotationOfTargetObject = currentObject.transform.rotation.eulerAngles;
			startingPosition = targetProviderTransform.position;
			startingRotation = currentObject.transform.localRotation;
			axis = currentObject.transform.up;
			targetProviderToObject = (targetProviderTransform.position) - currentObject.transform.position;
			perpVec = Vector3.Cross(axis, targetProviderToObject);
		}
	}

	void stopRotation() 
	{
		currentObject=null;
	}
}

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
	public bool isRotating;
	
	// Update is called once per frame
	void Update () {
		if(currentObject) { 
		
			Vector3 offsetVec = Vector3.Project(targetProviderTransform.position  - startingPosition, perpVec);
			Debug.DrawLine(currentObject.transform.position, currentObject.transform.position + offsetVec, Color.red);
			print(offsetVec);
			//float offset = offsetVec.magnitude;
			//currentObject.transform.rotation = startingRotation + Quaternion.AngleAxis;
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
			
			//GalleryItem item = targetProvider.targetObj.GetComponent<GalleryItem>();
			currentObject = targetProvider.targetObj.gameObject;

			CurrentWorldRotationOfTargetObject = currentObject.transform.rotation.eulerAngles;
			startingPosition = targetProviderTransform.position;
			axis = currentObject.transform.up;
			targetProviderToObject = (targetProviderTransform.position) - currentObject.transform.position;
			perpVec = Vector3.Cross(axis, targetProviderToObject);
			Debug.Log("We're rotating");
			//Debug.Log(CurrentWorldRotationOfTargetObject);
			isRotating = true;
		}
	}

	void stopRotation() 
	{
		currentObject=null;
		Debug.Log("StopRotating!");
	}
}

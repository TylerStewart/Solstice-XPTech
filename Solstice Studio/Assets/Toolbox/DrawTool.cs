using UnityEngine;
using System.Collections;

public class DrawTool : MonoBehaviour {
	public GameObject currentLine;
	public GameObject studioWorld;
	// Use this for initialization
	TrackedControllerTarget targetProvider;
	LineRenderer lr;
	int pos;
	void OnEnable () {
		SteamVR_InputManager.OnCursorHandTriggerPressDown += InputDown;
		SteamVR_InputManager.OnCursorHandTriggerPressUp += InputUp;
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
	}
	
	// Update is called once per frame
	/*void Update (){
		if(currentLine){
			lr.SetVertexCount(pos);
			//lr.SetPosition(pos, targetProvider.transform.position);
			pos++;
		}
	}
*/
	void InputDown(){
		endLine();
		startLine();
	}

	void InputUp(){
		endLine();
	}
	void startLine(){
		currentLine = new GameObject();
		lr = currentLine.AddComponent<LineRenderer>();
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, targetProvider.transform.position);
		lr.SetPosition(1, targetProvider.transform.position);
		pos = 2;
	}

	void endLine(){
		if(currentLine){
			currentLine.transform.parent=studioWorld.transform;
			currentLine=null;
		}
	}
}

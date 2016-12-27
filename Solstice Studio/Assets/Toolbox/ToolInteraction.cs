using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteraction : Tool {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void Press(){
		Select();
	}
	protected override void Release(){
		
	}

	void Select() {
		if(targetProvider.targetObj && targetProvider.targetObj.tag=="ToolsObj"){
			GameObject target = targetProvider.targetObj;
			Tool tool = target.GetComponentInChildren<Tool>();
			target.GetComponentInParent<ToolMenu>().ChangeSelected(tool);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
public class ToolMenu : MonoBehaviour {
	Animator ani;
	
	// Use this for initialization
	void Start () {
		SteamVR_InputManager.OnOffHandMenuPressDown += Press;
		ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Press(){
		ani.SetTrigger("Toggle");
	}

	public void ChangeSelected(Tool activate){
		Tool [] t = GetComponentsInChildren<Tool>();
		for(int i=0; i<t.Length;i++)
			t[i].enabled = false;;
		activate.enabled = true;
	}
}

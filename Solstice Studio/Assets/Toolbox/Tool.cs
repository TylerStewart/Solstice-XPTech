using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

	protected Transform cursorTransform;
	protected Transform targetProviderTransform;
	protected GameObject StudioWorld;
	public TargetProvider targetProvider;
	// Use this for initialization
	void Awake () {
		StudioWorld = GameObject.FindWithTag("WorldParent");
		Init();
	}

	 protected virtual void Init(){
		 #if UNITY_WSA_10_0
			//hololens platform specific stuff here
		#else
			targetProvider = FindObjectOfType<TrackedControllerTarget>();
			print(targetProvider);
			cursorTransform = SteamVR_InputManager.cursorTransform;
			targetProviderTransform = SteamVR_InputManager.cursorHand.transform;
			if(this.enabled)
				OnEnable();
			//SteamVR_InputManager.Move += Move;
		#endif
	 }

	void OnEnable(){
		 #if UNITY_WSA_10_0
			//hololens platform specific stuff here
		#else
			SteamVR_InputManager.OnCursorHandTriggerPressDown += Press;
			SteamVR_InputManager.OnCursorHandTriggerPressUp += Release;
			SteamVR_InputManager.OnCursorHandGripPress += Hold;
			//SteamVR_InputManager.Move += Move;
		#endif
	}

	void OnDisable(){
		SteamVR_InputManager.OnCursorHandTriggerPressDown -= Press;
		SteamVR_InputManager.OnCursorHandTriggerPressUp -= Release;
		SteamVR_InputManager.OnCursorHandGripPress -= Hold;
	}

	protected virtual void Press(){
	}

	protected virtual void Release(){

	}

	protected virtual void Hold(){

	}

	void Move(){

	}
}

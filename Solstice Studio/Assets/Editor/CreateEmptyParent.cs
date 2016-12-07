using UnityEngine;
using UnityEditor;
 
public class FixStupidEditorBehavior : MonoBehaviour {
    [MenuItem("GameObject/Create Empty Parent #&p")]
    static void CreateEmptyParent() {
        GameObject go = new GameObject("GameObject");
        if(Selection.activeTransform != null)
		go.transform.position = Selection.activeTransform.position;
		//go.transform.rotation = Selection.activeTransform.rotation;
		if(Selection.activeTransform.parent)
			go.transform.parent = Selection.activeTransform.parent;
        Selection.activeTransform.parent = go.transform;
    }
}
 
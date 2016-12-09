using UnityEngine;
using System.Collections;

public class GalleryItem : MonoBehaviour {
	public GameObject objPrefab;
	public GameObject modelParent;
	public float spawnScale;
	public Vector3 originalScale;
	public Vector3 originalRotation;

	// Use this for initialization
	void Start () {
		Renderer [] renders = GetComponentsInChildren<Renderer>();
  		for(int i=0;i<renders.Length;i++){
			  renders[i].material.renderQueue = 2002; // set their renderQueue
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPrefab(GameObject obj){
		objPrefab = obj;
		GameObject go = (GameObject) GameObject.Instantiate(objPrefab, modelParent.transform);
		go.transform.localPosition = Vector3.zero;
		originalScale = obj.transform.localScale;
		originalRotation = obj.transform.rotation.eulerAngles;
		go.transform.localScale = new Vector3 (spawnScale,spawnScale,spawnScale);
		MeshFilter meshFilter = go.GetComponent<MeshFilter>();
		if(meshFilter){
			Bounds bounds = meshFilter.mesh.bounds;
			float max = bounds.extents.x;
			if (max < bounds.extents.y) 
				max = bounds.extents.y;
			if (max < bounds.extents.z)
				max = bounds.extents.z;
             
         float scale = (modelParent.transform.localScale.x) / max;
         go.transform.localScale = new Vector3(scale, scale, scale);
		 go.GetComponent<Collider>().enabled=false;
		}
	}
}

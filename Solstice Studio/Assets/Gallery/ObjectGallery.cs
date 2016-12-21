using UnityEngine;
using System.Collections;

public class ObjectGallery : MonoBehaviour {
	[Tooltip("Number of items per row of gallery")]
	public float objectsPerRow;

	[Tooltip("Width in Units of gallery background")]
	public float galleryWidth;
	[Tooltip("Height in Units of gallery background")]
	public float galleryHeight;

	[Tooltip("Width in Units of gallery item prefab")]
	public float galleryItemWidth;//could probably get this using Collider.bounds but this works

	[Tooltip("Gallery item prefab to use; It must have a GalleryItem script attached!")]
	public GameObject galleryItemPrefab;
	public GameObject scrollParent;
	public GameObject [] galleryObjects;
	// Use this for initialization
	void Awake () {
		galleryObjects = Resources.LoadAll<GameObject>("");
		populateGallery(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void populateGallery(){
		float spacing = (galleryWidth - galleryItemWidth * objectsPerRow) / (objectsPerRow + 1);
		float offsetFirstBy = spacing + galleryItemWidth/2;
		float xOrigin = -galleryWidth/2 + offsetFirstBy;
		float yOrigin = galleryHeight/2 - offsetFirstBy;
		Vector3 itemPosition = new Vector3(xOrigin, yOrigin, -0.025f);
		int column=0, row=0;
		for(int i=0;i<galleryObjects.Length; i++){
			GameObject go = (GameObject)GameObject.Instantiate(galleryItemPrefab, scrollParent.transform);
			go.transform.localPosition = itemPosition;
			go.transform.localRotation = Quaternion.identity;
			go.GetComponent<GalleryItem>().setPrefab(galleryObjects[i]);
			column++;
			if(column==4){
				column = 0;
				row++;
				itemPosition.y -= galleryItemWidth + spacing;
				itemPosition.x = xOrigin;
			}
			else 
				itemPosition.x += galleryItemWidth + spacing;
		}
	}
}

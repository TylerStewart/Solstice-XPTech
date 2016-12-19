using UnityEngine;
using System.Collections;

public class VRCursor : MonoBehaviour
{
    [Tooltip("Maximum gaze distance for calculating a hit.")]
	public Mesh defaultMesh;
    public TargetProvider targetProvider;
    private void Awake()
    {
		targetProvider = FindObjectOfType<TrackedControllerTarget>();
    }

    private void Update()
    {
        Vector3 Position = targetProvider.Position;
        Vector3 Normal = targetProvider.Normal;
        GameObject Object = gameObject;

        if(targetProvider.Hit) {
            Object = targetProvider.HitInfo.collider.gameObject;
        }
        this.transform.position = Position;
        this.transform.up = Normal;
        CursorProvider Provider = Object.GetComponentInParent<CursorProvider>();
        if (Provider)
        {
			this.transform.localScale = Provider.transform.lossyScale;
            this.GetComponent<MeshFilter>().mesh = Provider.HoverCursor;			
        }
		else
        this.transform.localScale = new Vector3(1,1,1);
			this.GetComponent<MeshFilter>().mesh = defaultMesh;
    }
}
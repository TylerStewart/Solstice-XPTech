using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class AnimatedHighlighter : MonoBehaviour, Highlighter {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Highlight(GameObject go){
		animator.SetBool("Highlighted", true);
	}

	public void UnHighlight(){
		animator.SetBool("Highlighted", false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool isRunningPressed = Input.GetAxis ("Vertical") > 0;
		animator.SetBool ("IsRunning", isRunningPressed);
	}
}

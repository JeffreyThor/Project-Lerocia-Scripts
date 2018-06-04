using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour {

	Animator animator;
	CharacterController enemy;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		enemy = GetComponent <CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool isRunning = (enemy.velocity != Vector3.zero);
		animator.SetBool ("IsRunning", isRunning);
	}
}

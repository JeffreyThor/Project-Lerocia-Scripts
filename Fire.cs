using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Attack {

	public Fire() {
		Name = "Fire";
		Cost = 200;
		BaseDamage = 2;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Fire";
		abilityAnimationTrigger = "FireTrigger";
	}

}

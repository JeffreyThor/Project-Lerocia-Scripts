using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAttack : Attack {

	public PowerAttack() {
		Name = "PowerAttack";
		Cost = 200;
		BaseDamage = 2;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Power Attack";
		abilityAnimationTrigger = "PowerAttackTrigger";
	}

}

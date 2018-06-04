using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Attack {

	public Freeze() {
		Name = "Freeze";
		Cost = 200;
		BaseDamage = 0;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Freeze";
		abilityAnimationTrigger = "FreezeTrigger";
	}

	protected override void computeAbility (Character character, Enemy enemy)
	{
		if (enemy.AttackRate < enemy.MaxAttackRate + enemy.rateOffset) {
			enemy.AttackRate += 1;
		} else {
			Debug.Log ("Attack rate already at slowest speed");
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Attack {

	public Defend() {
		Name = "Defend";
		Cost = 100;
		BaseDamage = 0;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Defend";
		abilityAnimationTrigger = "DefendTrigger";
	}

	protected override void computeAbility (Character character, Enemy enemy)
	{
		character.Defense += 20;
	}


}

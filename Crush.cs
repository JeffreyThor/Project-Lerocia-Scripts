using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : Attack {

	public Crush() {
		Name = "Crush";
		Cost = 200;
		BaseDamage = 1;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Crush";
		abilityAnimationTrigger = "CrushTrigger";
	}

	protected override void computeAbility (Character character, Enemy enemy)
	{
		base.computeAbility (character, enemy);
		enemy.Defense -= 20;
	}

}

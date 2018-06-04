using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Attack {

	public Heal() {
		Name = "Heal";
		Cost = 100;
		BaseDamage = 0;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Heal";
		abilityAnimationTrigger = "HealTrigger";
	}

	protected override void computeAbility (Character character, Enemy enemy)
	{
		character.gainHealth(Random.Range(character.MaxHealth/6, character.MaxHealth/2));
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : Attack {

	public Steal() {
		Name = "Steal";
		Cost = 200;
		BaseDamage = 1;
		abilityAnimationName = "Steal";
		abilityAnimationTrigger = "StealTrigger";
	}

	protected override void computeAbility (Character character, Enemy enemy)
	{
		base.computeAbility (character, enemy);
		character.GoldToAdd += enemy.Level * 8;
	}

}

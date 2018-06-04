using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAttack : Attack {

	public QuickAttack() {
		Name = "QuickAttack";
		Cost = 50;
		BaseDamage = 1;
		abilityAnimationName = "Quick Attack";
		abilityAnimationTrigger = "QuickAttackTrigger";
	}

}

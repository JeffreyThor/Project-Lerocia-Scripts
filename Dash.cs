using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Attack {

	public Dash() {
		Name = "Dash";
		Cost = 100;
		BaseDamage = 1;
		abilityAnimationName = "Dash";
		abilityAnimationTrigger = "DashTrigger";
	}

}

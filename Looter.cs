using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looter : Character {

	public Looter (string characterType, int level) : base(characterType, level){
		CurrentHealth = level*level*10;
		MaxHealth = level*level*10;
		Damage = 1.5;
		MaxDamage = Damage;
		Defense = 100;
		MaxDefense = Defense;
		Energy = 0;
		EnergyFillRate = 6;
		CurrentQueueSize = 0;
		MaxQueueSize = 4;
		CriticalPercentage = 15;
		MaxCriticalPercentage = CriticalPercentage;
		MissPercentage = 15;
		MaxMissPercentage = MissPercentage;
		ExperienceMultiplier = 1.0;
		GoldMultiplier = 2.0;
		attackOne = new Attack ();
		attackTwo = new Steal ();
		attackThree = new QuickAttack ();
		attackFour = new Dash ();
	}

}

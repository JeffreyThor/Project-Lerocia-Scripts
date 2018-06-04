using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character {

	public Warrior (string characterType, int level) : base(characterType, level){
		CurrentHealth = level*level*10;
		MaxHealth = level*level*10;
		Damage = 1.8;
		MaxDamage = Damage;
		Defense = 100;
		MaxDefense = Defense;
		Energy = 0;
		EnergyFillRate = 5;
		CurrentQueueSize = 0;
		MaxQueueSize = 3;
		CriticalPercentage = 15;
		MaxCriticalPercentage = CriticalPercentage;
		MissPercentage = 10;
		MaxMissPercentage = MissPercentage;
		ExperienceMultiplier = 1.0;
		GoldMultiplier = 1.0;
		attackOne = new Attack ();
		attackTwo = new PowerAttack ();
		attackThree = new Defend ();
		attackFour = new Crush ();
	}

}

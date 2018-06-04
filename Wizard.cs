using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character {

	public Wizard (string characterType, int level) : base(characterType, level){
		CurrentHealth = level*level*10;
		MaxHealth = level*level*10;
		Damage = 1.5;
		MaxDamage = Damage;
		Defense = 100;
		MaxDefense = Defense;
		Energy = 0;
		EnergyFillRate = 5;
		CurrentQueueSize = 0;
		MaxQueueSize = 5;
		CriticalPercentage = 0;
		MaxCriticalPercentage = CriticalPercentage;
		MissPercentage = 0;
		MaxMissPercentage = MissPercentage;
		ExperienceMultiplier = 1.0;
		GoldMultiplier = 1.0;
		attackOne = new Attack ();
		attackTwo = new Heal ();
		attackThree = new Fire ();
		attackFour = new Freeze ();
	}

}

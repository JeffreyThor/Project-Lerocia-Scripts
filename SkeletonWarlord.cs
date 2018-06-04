using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarlord : Enemy {

	public SkeletonWarlord (string enemyType, int level) : base(enemyType, level){
		CurrentHealth = level*level*12;
		MaxHealth = level*level*12;
		Damage = 2.0;
		MaxDamage = Damage;
		AttackRate = 6.0f;
		MaxAttackRate = AttackRate;
		rateOffset = 2.0f;
		CriticalPercentage = 12;
		MissPercentage = 12;
		Defense = 100;
		MaxDefense = Defense;
		attacks = new EnemyAttack[1];
		attacks [0] = new EnemyAttack ();
	}
}

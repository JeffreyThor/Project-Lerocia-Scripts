using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSorcerer : Enemy {

	public SkeletonSorcerer (string enemyType, int level) : base(enemyType, level){
		CurrentHealth = level*level*8;
		MaxHealth = level*level*8;
		Damage = 2.0;
		MaxDamage = Damage;
		AttackRate = 8.0f;
		MaxAttackRate = AttackRate;
		rateOffset = 2.0f;
		CriticalPercentage = 8;
		MissPercentage = 15;
		Defense = 100;
		MaxDefense = Defense;
		attacks = new EnemyAttack[1];
		attacks [0] = new EnemyAttack ();
	}
}

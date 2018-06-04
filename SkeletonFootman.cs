using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFootman : Enemy {

	public SkeletonFootman (string enemyType, int level) : base(enemyType, level){
		CurrentHealth = level*level*10;
		MaxHealth = level*level*10;
		Damage = 1.2;
		MaxDamage = Damage;
		AttackRate = 4.0f;
		MaxAttackRate = AttackRate;
		rateOffset = 2.0f;
		CriticalPercentage = 8;
		MissPercentage = 0;
		Defense = 100;
		MaxDefense = Defense;
		attacks = new EnemyAttack[1];
		attacks [0] = new EnemyAttack ();
	}
}

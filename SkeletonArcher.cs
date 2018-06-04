using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArcher : Enemy {

	public SkeletonArcher (string enemyType, int level) : base(enemyType, level){
		CurrentHealth = level*level*10;
		MaxHealth = level*level*10;
		Damage = 1.8;
		MaxDamage = Damage;
		AttackRate = 7.0f;
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

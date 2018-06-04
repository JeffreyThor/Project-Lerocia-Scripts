using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

	public string EnemyType{ get; set; }
	public int Level{ get; set; }
	public int CurrentHealth{ get; set; }
	public int MaxHealth{ get; set; }
	public double Damage{ get; set; }
	public double MaxDamage{ get; set; }
	public int Defense{ get; set; } // This is used as a percentage
	public int MaxDefense{ get; set; }
	public float AttackRate{ get; set; }
	public float MaxAttackRate{ get; set; }
	public int CriticalPercentage{ get; set; } // This is used as a percentage
	public int MissPercentage{ get; set; } // This is used as a percentage
	public float rateOffset;
	public string attackOneName;
	public string attackTwoName;
	public EnemyAttack[] attacks;

	public Enemy(string enemyType, int level) {
		this.EnemyType = enemyType;
		this.Level = level;
		attacks = new EnemyAttack[0];
	}

//	public IEnumerator pickAttack() {
//		yield return new WaitForSeconds (Random.Range(AttackRate - rateOffset, AttackRate + rateOffset));
//		attacks [Random.Range (0, attacks.Length - 1)].executeAttack ();
//	}

	public void takeDamage(ref int damage) {
		damage = (int)(damage / ((float)Defense / 100));
		CurrentHealth -= damage;
	}

	public void resetStats() {
		Damage = MaxDamage;
		Defense = MaxDefense;
		AttackRate = MaxAttackRate;
	}

}

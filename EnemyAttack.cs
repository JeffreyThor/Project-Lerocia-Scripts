using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack  {

	public string Name{ get; set; }
	public int BaseDamage{ get; set; }
	public Animator animator;
	public RuntimeAnimatorController animatorController;
	public string abilityAnimationTrigger;
	public string abilityAnimationName;

	public EnemyAttack() {
		Name = "Attack";
		BaseDamage = 2;

	}

	public void setInitialReferences() {
		Debug.Log ("Initial References Set");
		animator = GameObject.FindGameObjectWithTag ("CollisionEnemy").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Attack";
		abilityAnimationTrigger = "attackTrigger";
	}

	protected float setTimer() {
		for(int i = 0; i<animatorController.animationClips.Length; i++)                 //For all animations
		{
			Debug.Log ("Animation Clip: " + animatorController.animationClips[i]);
			if(animatorController.animationClips[i].name == abilityAnimationName)        //If it has the same name as your clip
			{
				Debug.Log ("Found " + abilityAnimationName);
				return animatorController.animationClips[i].length;
			}
		}
		return 0;
	}

	protected virtual void computeAbility(Character character, Enemy enemy) {
		int damage;
		damage = (int) ((Random.Range(-enemy.Level + 1, enemy.Level) + (Mathf.Pow(enemy.Level, 2))) * enemy.Damage);
		if (Random.Range (1, 100) <= enemy.CriticalPercentage) {
			Debug.Log ("Critical Hit!");
			damage *= 2;
		} else if (Random.Range (1, 100) <= enemy.MissPercentage) {
			Debug.Log ("Miss!");
			damage = 0;
		} else {
			Debug.Log ("Hit");
		}
		character.takeDamage (ref damage);
	}

	public IEnumerator executeAttack() {
		Character character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().character;
		Enemy enemy = GameObject.FindGameObjectWithTag ("CollisionEnemy").GetComponent<Player> ().enemy;
		animator.SetTrigger (abilityAnimationTrigger);
		yield return new WaitForSeconds(setTimer());
		computeAbility (character, enemy);
		yield return new WaitForSeconds (Random.Range(enemy.AttackRate - enemy.rateOffset, enemy.AttackRate + enemy.rateOffset));
		GameObject.Find ("BattleSystem").GetComponent<BattleController> ().enemyAttack ();

//		Debug.Log ("Enemy Attack!");
//		Enemy enemy = GameObject.FindGameObjectWithTag ("CollisionEnemy").GetComponent<Player> ().enemy;
//		GameObject.FindGameObjectWithTag ("CollisionEnemy").GetComponent<EnemyMaster> ().CallEventEnemyAttack ();
//		int damage;
//		damage = (int) ((Random.Range(-enemy.Level + 1, enemy.Level) + (Mathf.Pow(enemy.Level, 2))) * enemy.Damage);
//		if (Random.Range (1, 100) <= enemy.CriticalPercentage) {
//			Debug.Log ("Critical Hit!");
//			damage *= 2;
//		} else if (Random.Range (1, 100) <= enemy.MissPercentage) {
//			Debug.Log ("Miss!");
//			damage = 0;
//		} else {
//			Debug.Log ("Hit");
//		}
//		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().character.CurrentHealth -= damage;
	}

}

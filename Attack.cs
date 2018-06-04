using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

	public string Name{ get; set; }
	public int Cost{ get; set; }
	public float BaseDamage{ get; set; }
	public Animator animator;
	public RuntimeAnimatorController animatorController;
	public string abilityAnimationTrigger;
	public string abilityAnimationName;
	public float time;

	public Attack() {
		Name = "Attack";
		Cost = 100;
		BaseDamage = 1;
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		animatorController = animator.runtimeAnimatorController;
		abilityAnimationName = "Attack";
		abilityAnimationTrigger = "AttackTrigger";
	}

	protected void setTimer() {
		for(int i = 0; i<animatorController.animationClips.Length; i++)                 //For all animations
		{
			if(animatorController.animationClips[i].name == abilityAnimationName)        //If it has the same name as your clip
			{
				Debug.Log ("Found " + abilityAnimationName);
				time = animatorController.animationClips[i].length;
			}
		}
	}

	protected virtual void computeAbility(Character character, Enemy enemy) {
		int damage;
		damage = (int) ((Random.Range(1 - character.Level, character.Level) + (Mathf.Pow(character.Level, 2))) * character.Damage * BaseDamage);
		if (Random.Range (1, 100) <= character.CriticalPercentage) {
			Debug.Log ("Critical Hit!");
			damage *= 2;
		} else if (Random.Range (1, 100) <= character.MissPercentage) {
			Debug.Log ("Miss!");
			damage = 0;
		} else {
			Debug.Log ("Hit");
		}
		enemy.takeDamage (ref damage);
		FloatingTextController.CreateFloatingEnemyText (damage.ToString ());
	}

	public IEnumerator executeAttack() {
		Character character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().character;
		Enemy enemy = GameObject.FindGameObjectWithTag ("CollisionEnemy").GetComponent<Player> ().enemy;
		animator.SetTrigger (abilityAnimationTrigger);
		setTimer ();
		yield return new WaitForSeconds(time);
		computeAbility (character, enemy);
		Debug.Log (Name);
		GameObject.Find ("BattleSystem").GetComponent<BattleController> ().iconTesting ();
		GameObject.Find ("BattleSystem").GetComponent<BattleController> ().executeQueue ();
	}

}

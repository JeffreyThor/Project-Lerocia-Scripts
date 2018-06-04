using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

	EnemyMaster enemyMaster;
	Animator animator;

	void OnEnable() {
		SetInitialReferences ();
		enemyMaster.EventEnemyWalking += SetAnimationToWalk;
		enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
		enemyMaster.EventEnemyBattle += SetAnimationToCombat;
	}

	void OnDisable() {
		enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
		enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
		enemyMaster.EventEnemyBattle -= SetAnimationToCombat;
	}

	void SetInitialReferences() {
		enemyMaster = GetComponent<EnemyMaster> ();
		if (GetComponent<Animator> () != null) {
			animator = GetComponent<Animator> ();
		}
	}

	void SetAnimationToWalk() {
		if (animator != null) {
			if (animator.enabled) {
				animator.SetBool ("isWalking", true);
			}
		}
	}

	void SetAnimationToIdle() {
		if (animator != null) {
			if (animator.enabled) {
				animator.SetBool ("isWalking", false);
			}
		}
	}

	void SetAnimationToCombat() {
		if (animator != null) {
			if (animator.enabled) {
				animator.SetBool ("isBattling", true);
			}
		}
	}

//	void SetAnimationToAttack() {
//		if (animator != null) {
//			if (animator.enabled) {
//				animator.SetTrigger ("attackTrigger");
//			}
//		}
//	}

	void DisableAnimator() {
		if (animator != null) {
			animator.enabled = false;
		}
	}

}

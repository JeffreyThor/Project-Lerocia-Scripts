using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour {

	public Transform target;
	public bool isOnRoute;
	public bool isWandering;

	public delegate void GeneralEventHandler();
	public event GeneralEventHandler EventEnemyWalking;
	public event GeneralEventHandler EventEnemyReachedNavTarget;
	public event GeneralEventHandler EventEnemyLostTarget;
	public event GeneralEventHandler EventEnemyBattle;
	public event GeneralEventHandler EventEnemyAttack;

	public delegate void NavTargetEventHandler(Transform targetTransform);
	public event NavTargetEventHandler EventEnemySetNavTarget;

	public void CallEventEnemySetNavTarget(Transform targetTransform) {
		if (EventEnemySetNavTarget != null) {
			EventEnemySetNavTarget (targetTransform);
		}
		target = targetTransform;
	}

	public void CallEventEnemyWalking() {
		if (EventEnemyWalking != null) {
			EventEnemyWalking ();
		}
	}

	public void CallEventEnemyReachedNavTarget() {
		if (EventEnemyReachedNavTarget != null) {
			EventEnemyReachedNavTarget ();
			bool enemyTrackingPlayer = true;
			foreach (GameObject enemy in GameObject.Find("GameManager").GetComponent<GameController>().enemies) {
				if (enemy.GetComponent<EnemyMaster> ().isWandering) {
					enemyTrackingPlayer = false;
				} else {
					enemyTrackingPlayer = true;
					break;
				}
			}
			if (!enemyTrackingPlayer) {
				MusicPlayer.PlayOverworldMusic ();
			}
		}
	}

	public void CallEventEnemyLostTarget() {
		if (EventEnemyLostTarget != null) {
			EventEnemyLostTarget ();
		}

		target = null;
	}

	public void CallEventEnemyBattle() {
		if (EventEnemyBattle != null) {
			EventEnemyBattle ();
		}
	}

	public void CallEventEnemyAttack() {
		if (EventEnemyAttack != null) {
			EventEnemyAttack ();
		}
	}

}

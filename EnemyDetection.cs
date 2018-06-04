using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {

	EnemyMaster enemyMaster;
	Transform myTransform;
	public Transform head;
	public LayerMask playerLayer;
	public LayerMask sightLayer;
	float checkRate;
	float nextCheck;
	float detectRadius = 50;
	RaycastHit hit;

	void OnEnable() {
		SetInitialReferences ();
	}

	void OnDisable() {

	}

	void Update () {
		CarryOutDetection ();
	}

	void SetInitialReferences() {
		enemyMaster = GetComponent<EnemyMaster> ();
		myTransform = transform;

		if (head == null) {
			head = myTransform;
		}

		checkRate = Random.Range (0.8f, 1.2f);
	}

	void CarryOutDetection() {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;

			Collider[] colliders = Physics.OverlapSphere (myTransform.position, detectRadius, playerLayer);

			if (colliders.Length > 0) {
				foreach (Collider potentialTargetCollider in colliders) {
					if (potentialTargetCollider.CompareTag ("Player")) {
						if (CanPotentialTargetBeSeen (potentialTargetCollider.transform)) {
							break;
						}
					}
				}
			} else {
				enemyMaster.CallEventEnemyLostTarget ();
			}
		}
	}

	bool CanPotentialTargetBeSeen(Transform potentialTarget) {
		if (Physics.Linecast (head.position, potentialTarget.position, out hit, sightLayer)) {
			if (hit.transform == potentialTarget) {
				MusicPlayer.PlayEnemyFollowingMusic ();
				enemyMaster.CallEventEnemySetNavTarget (potentialTarget);
				return true;
			} else {
				enemyMaster.CallEventEnemyLostTarget ();
				return false;
			}
		} else {
			enemyMaster.CallEventEnemyLostTarget ();
			return false;
		}
	}

	void DisableThis() {
		this.enabled = false;
	}
}

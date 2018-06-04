using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavPursue : MonoBehaviour {

	EnemyMaster enemyMaster;
	NavMeshAgent myNavMeshAgent;
	float checkRate;
	float nextCheck;

	void OnEnable() {
		SetInitialReferences ();
	}

	void OnDisable() {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;
			TryToChaseTarget ();
		}
	}

	void SetInitialReferences() {
		enemyMaster = GetComponent<EnemyMaster> ();
		if (GetComponent<NavMeshAgent> () != null) {
			myNavMeshAgent = GetComponent<NavMeshAgent> ();
		}
		checkRate = Random.Range (0.1f, 0.2f);
	}

	void TryToChaseTarget() {
		if (enemyMaster.target != null && myNavMeshAgent != null) {
			myNavMeshAgent.SetDestination (enemyMaster.target.position);
			if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance) {
				enemyMaster.CallEventEnemyWalking ();
				enemyMaster.isOnRoute = true;
			}
		}
	}

	void DisableThis() {
		if (myNavMeshAgent != null) {
			myNavMeshAgent.enabled = false;
		}

		this.enabled = false;
	}
}

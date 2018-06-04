using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavDestinationReached : MonoBehaviour {

	EnemyMaster enemyMaster;
	NavMeshAgent myNavMeshAgent;
	float checkRate;
	float nextCheck;
	float offsetRadius = 1;

	void OnEnable() {
		SetInitialReferences ();
	}

	void OnDisable() {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;
			CheckIfDestinationReached ();
		}
	}

	void SetInitialReferences() {
		enemyMaster = GetComponent<EnemyMaster> ();
		if (GetComponent<NavMeshAgent> () != null) {
			myNavMeshAgent = GetComponent<NavMeshAgent> ();
		}
		checkRate = Random.Range (0.3f, 0.4f);
	}

	void CheckIfDestinationReached() {
		if (enemyMaster.isOnRoute) {
			if (myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance + offsetRadius) {
				enemyMaster.isOnRoute = false;
				enemyMaster.CallEventEnemyReachedNavTarget ();
			}
		}
	}

	void DisableThis() {

	}
}

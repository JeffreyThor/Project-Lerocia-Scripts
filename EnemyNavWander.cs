using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavWander : MonoBehaviour {

	EnemyMaster enemyMaster;
	NavMeshAgent myNavMeshAgent;
	float checkRate;
	float nextCheck;
	float wanderRange = 10;
	Transform myTransform;
	NavMeshHit navHit;
	Vector3 wanderTarget;

	void OnEnable() {
		SetInitialReferences ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextCheck) {
			nextCheck = Time.time + checkRate;
			CheckIfIShouldWander ();
		}
	}

	void SetInitialReferences() {
		enemyMaster = GetComponent<EnemyMaster> ();
		if (GetComponent<NavMeshAgent> () != null) {
			myNavMeshAgent = GetComponent<NavMeshAgent> ();
		}
		checkRate = Random.Range (0.3f, 0.4f);
		myTransform = transform;
	}

	void CheckIfIShouldWander() {
		if (enemyMaster.target == null && !enemyMaster.isOnRoute) {
			enemyMaster.isWandering = true;
			if (RandomWanderTarget (myTransform.parent.position, wanderRange, out wanderTarget)) {
				myNavMeshAgent.SetDestination (wanderTarget);
				enemyMaster.isOnRoute = true;
				enemyMaster.CallEventEnemyWalking ();
			}
		} else if (!enemyMaster.isOnRoute) {
			enemyMaster.isWandering = false;
		}
	}

	bool RandomWanderTarget(Vector3 center, float range, out Vector3 result) {
		Vector3 randomPoint = center + Random.insideUnitSphere * wanderRange;
		if (NavMesh.SamplePosition (randomPoint, out navHit, 1.0f, NavMesh.AllAreas)) {
			result = navHit.position;
			return true;
		} else {
			result = center;
			return false;
		}
	}

	void DisableThis() {
		this.enabled = false;
	}
}

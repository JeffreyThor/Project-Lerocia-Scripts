using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour {

	GameObject target;
	NavMeshAgent agent;
	GameObject spawner;
	GameController gameController;
	NavMeshHit navHit;
	Vector3 wanderTarget;
	float checkRate = 5;
	float nextCheck;
	bool isOnRoute;
	public float chaseDistance;
	public float wanderRange;
	private float distance;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameManager").GetComponent<GameController> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		agent = GetComponent<NavMeshAgent> ();
		//TO-DO
		//Find a way to set spawner to the actual spawner object
		//that this enemy instance is created from
//		spawner = GameObject.Find ("EnemyZoneOne");
		spawner = this.transform.parent.gameObject;
//		foreach(GameObject enemy in gameController.enemies){
//			enemy.SetActive (true);
//		}
	}
	
	// Update is called once per frame
	public void Update () {
		distance = Vector3.Distance (target.transform.position, spawner.transform.position);
		if (distance < chaseDistance) {
			agent.SetDestination (target.transform.position);
			isOnRoute = true;
		} else {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				if (!isOnRoute) {
					if (RandomWanderTarget (transform.position, wanderRange, out wanderTarget)) {
						agent.SetDestination (wanderTarget);
						isOnRoute = true;
					}
				}
			}
//			agent.SetDestination (spawner.transform.position);
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
}

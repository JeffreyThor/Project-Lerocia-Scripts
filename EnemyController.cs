using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance) {
			lookAtPlayer ();
		}
		if (fpsTargetDistance < attackDistance) {
			attack ();
		} else {

		}
	}

	void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack() {
		transform.Translate (new Vector3 (0, 0, enemyMovementSpeed * Time.deltaTime));
	}
}

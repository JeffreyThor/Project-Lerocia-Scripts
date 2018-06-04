using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemySelection : MonoBehaviour {

	GameObject enemyCollided;
	GameObject player;
	Animator animator;
	GameController gameController;

	void Start() {
		
		enemyCollided = GameObject.FindGameObjectWithTag("CollisionEnemy");
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = player.GetComponent<Animator> ();
		GameObject.Find("GameManager").GetComponent<GameController>().playerWorldLocation = player.transform.position;
		GameObject.Find("GameManager").GetComponent<GameController>().playerWorldRotation = player.transform.rotation;

		gameController = GameObject.Find ("GameManager").GetComponent<GameController> ();

		playerControllerStatus (false);
		enemyControllerStatus (false);

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		animator.SetBool ("IsRunning", false);
		enemyCollided.GetComponent<EnemyMaster> ().CallEventEnemyReachedNavTarget ();
		player.transform.position = new Vector3 (102, 81, -51);
		enemyCollided.transform.position = new Vector3 (99, 82, -44);

	}

	public void playerControllerStatus(bool status) {
//		player.GetComponent<CharacterController> ().enabled = status;
		player.GetComponent<MouseLook> ().enabled = status;
		player.GetComponent<CharacterMotor> ().canControl = status;
//		player.GetComponent<FPSInputController> ().enabled = status;
		player.GetComponent<AnimationController> ().enabled = status;
		player.GetComponent<CursorController> ().enabled = status;
		player.GetComponent<PlayerCollision> ().enabled = status;
	}

	void enemyControllerStatus(bool status) {
		enemyCollided.GetComponent<EnemyDetection> ().enabled = status;
		enemyCollided.GetComponent<EnemyNavPursue> ().enabled = status;
		enemyCollided.GetComponent<EnemyNavDestinationReached> ().enabled = status;
		enemyCollided.GetComponent<EnemyNavWander> ().enabled = status;
		enemyCollided.GetComponent<NavMeshAgent> ().enabled = status;
	}
}

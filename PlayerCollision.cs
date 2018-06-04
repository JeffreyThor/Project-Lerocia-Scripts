using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerCollision : MonoBehaviour {

	GameController gameController;
	GameObject zoneSpawner;

	void Start() {
		gameController = GameObject.Find ("GameManager").GetComponent<GameController> ();
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "Enemy") {
			zoneSpawner = hit.gameObject.transform.parent.gameObject;
			hit.gameObject.tag = "CollisionEnemy";
			gameController.enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach(GameObject enemy in gameController.enemies){
				enemy.GetComponent<NavMeshAgent> ().enabled = false;
				enemy.SetActive (false);
			}
			SceneManager.LoadScene ("Battle");
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
//	public GameObject[] zoneEnemies;
	public List<GameObject> zoneEnemies;
	public float spawnTime;
	public int spawnRange;
	public int maxNumEnemies;
	public int level;
	public int levelOffset;
	public float heightBuffer;
	public LayerMask terrainLayer;
	GameController gameController;
	float xPosition;
	float yPosition;
	float zPosition;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameManager").GetComponent<GameController> ();
		zoneEnemies = new List<GameObject> ();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
//		print ("Number of enemies: " + gameController.enemies.Length);
	}

	void Spawn() {
		if (zoneEnemies.Count < maxNumEnemies && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overworld")) {
			//		GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), 2, 0), Quaternion.identity);
			xPosition = this.transform.position.x + Random.Range(-spawnRange, spawnRange);
			zPosition = this.transform.position.z + Random.Range (-spawnRange, spawnRange);
			if (Physics.Raycast (new Vector3 (xPosition, 9999f, zPosition), Vector3.down, out hit, Mathf.Infinity, terrainLayer)) {
				yPosition = hit.point.y;
			}
			yPosition += heightBuffer;
			GameObject enemy = Instantiate (enemyPrefab, new Vector3(xPosition, yPosition, zPosition) , Quaternion.identity);
			enemy.GetComponent<Player> ().CreateEnemy(enemyPrefab.name, level + Random.Range(-levelOffset, levelOffset));
//		enemy.transform.parent = this.transform;
//			DontDestroyOnLoad (enemy);
			enemy.transform.parent = this.transform;
			zoneEnemies.Add (enemy);
			gameController.enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		} else {
//			print ("Too many enemies or in combat");
		}
	}
}

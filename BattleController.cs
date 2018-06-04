using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

	GameObject player;
	GameObject enemy;
	Button attackButtonOne;
	Button attackButtonTwo;
	Button attackButtonThree;
	Button attackButtonFour;
	Button executeButton;
//	Button fleeButton;
	GameObject energyBar;
	EnergyBar energyBarScript;
	GameObject characterHealthBar;
	public GameObject enemyHealthBar;
	GameObject enemyHealthBarTwo;
	GameObject enemyCanvas;
	Camera battleCamera;
	Character playerCharacter;
	Enemy playerEnemy;
	int energyBarSize;
	List<GameObject> attackImage;
	Attack currentAttack;
//	IEnumerator coroutine;
	IEnumerator attackCoroutine;
	EnemyMaster enemyMaster;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("CollisionEnemy");
		playerCharacter = player.GetComponent<Player> ().character;
		playerEnemy = enemy.GetComponent<Player> ().enemy;
		for (int i = 0; i < playerEnemy.attacks.Length; i++) {
			playerEnemy.attacks [i].setInitialReferences ();
		}
		playerCharacter.Energy = 0;
		playerCharacter.CurrentQueueSize = 0;
		energyBar = GameObject.Find ("Energy Bar");
		energyBarScript = energyBar.GetComponent<EnergyBar> ();
		characterHealthBar = GameObject.Find ("Health Bar");
		enemyHealthBar = Instantiate (Resources.Load ("Enemy Health Bar") as GameObject);
		enemyHealthBar.transform.SetParent (GameObject.Find("Enemy Canvas").transform);
		enemyHealthBarTwo = GameObject.Find ("Enemy Health Bar 2");
		enemyCanvas = GameObject.Find ("Enemy Canvas");
		battleCamera = GameObject.Find ("Battle Camera").GetComponent<Camera> ();
		enemyHealthBar.GetComponent<RectTransform> ().localPosition = new Vector3(0, 60, 0);
		enemyHealthBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 20);
		enemyHealthBar.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		attackButtonOne = GameObject.Find ("AttackButtonOne").GetComponent<Button> ();
		attackButtonOne.onClick.AddListener (delegate{queueAttack(playerCharacter.attackOne);});
		attackButtonTwo = GameObject.Find ("AttackButtonTwo").GetComponent<Button> ();
		attackButtonTwo.onClick.AddListener (delegate{queueAttack(playerCharacter.attackTwo);});
		attackButtonThree = GameObject.Find ("AttackButtonThree").GetComponent<Button> ();
		attackButtonThree.onClick.AddListener (delegate{queueAttack(playerCharacter.attackThree);});
		attackButtonFour = GameObject.Find ("AttackButtonFour").GetComponent<Button> ();
		attackButtonFour.onClick.AddListener (delegate{queueAttack(playerCharacter.attackFour);});
		executeButton = GameObject.Find ("ExecuteButton").GetComponent<Button> ();
		executeButton.onClick.AddListener (checkIfExecuting);
		energyBarSize = playerCharacter.MaxQueueSize * 100;
		energyBarScript.valueCurrent = energyBarScript.valueMin;
		energyBarScript.valueMax = energyBarSize;
		energyBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (energyBarSize, 30);
		attackImage = new List<GameObject> ();
		InvokeRepeating("fillEnergy", 0.0f, 0.1f);
//		coroutine = playerEnemy.pickAttack ();
//		StartCoroutine (coroutine);
		MusicPlayer.PlayEnemyEncounterMusic ();
		enemyMaster = enemy.GetComponent<EnemyMaster> ();
		enemyMaster.CallEventEnemyBattle ();
		enemyAttack();

		GameObject.Find ("Enemy Name").GetComponentInChildren<Text> ().text = playerEnemy.EnemyType;
		GameObject.Find ("Enemy Level").GetComponentInChildren<Text> ().text = "Level: " + playerEnemy.Level;
		GameObject.Find ("Character Name").GetComponentInChildren<Text> ().text = playerCharacter.CharacterType;
		GameObject.Find ("AttackButtonOne").GetComponentInChildren<Text> ().text = playerCharacter.attackOne.Name;
		GameObject.Find ("AttackButtonTwo").GetComponentInChildren<Text> ().text = playerCharacter.attackTwo.Name;
		GameObject.Find ("AttackButtonThree").GetComponentInChildren<Text> ().text = playerCharacter.attackThree.Name;
		GameObject.Find ("AttackButtonFour").GetComponentInChildren<Text> ().text = playerCharacter.attackFour.Name;
	}
	
	// Update is called once per frame
	void Update () {
		enemy.transform.LookAt (player.transform.position);
		player.transform.LookAt (enemy.transform.position);
		enemyCanvas.transform.position = enemy.transform.position;
		enemyHealthBar.GetComponent<RectTransform>().localPosition = new Vector3(0, 60, 0);
		enemyHealthBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, 20);
		enemyCanvas.transform.LookAt(enemyCanvas.transform.position + battleCamera.transform.rotation * Vector3.forward, battleCamera.transform.rotation * Vector3.up);
		enemyHealthBar.GetComponent<EnergyBar> ().valueCurrent = (int)((double)playerEnemy.CurrentHealth / (double)playerEnemy.MaxHealth * 100);
		enemyHealthBarTwo.GetComponent<EnergyBar> ().valueCurrent = (int)((double)playerEnemy.CurrentHealth / (double)playerEnemy.MaxHealth * 100);
		characterHealthBar.GetComponent<EnergyBar> ().valueCurrent = (int)((double)playerCharacter.CurrentHealth / (double)playerCharacter.MaxHealth * 100);
		if (playerEnemy.CurrentHealth <= 0) {
			Victory ();
		} else if (playerCharacter.CurrentHealth <= 0) {
			//TO-DO
			//Handle player defeat
			Defeat ();
		}
	}

	void fillEnergy() {
		if (playerCharacter.Energy <= energyBarSize) {
			if (!playerCharacter.Executing) {
				playerCharacter.Energy += playerCharacter.EnergyFillRate;
			}
			energyBarScript.valueCurrent = playerCharacter.Energy;
		}
	}

	public void enemyAttack() {
		attackCoroutine = playerEnemy.attacks [Random.Range (0, playerEnemy.attacks.Length - 1)].executeAttack ();
		StartCoroutine (attackCoroutine);
	}

	void queueAttack(Attack attack) {
		if (playerCharacter.CurrentQueueSize + attack.Cost <= energyBarSize && !playerCharacter.Executing) {
			playerCharacter.queueAttack (attack);
			placeAttackIcon (attack);
		} else {
			Debug.Log ("Full queue or executing");
		}
	}

	void checkIfExecuting() {
		if (!playerCharacter.Executing) {
			executeQueue ();
		} else {
			Debug.Log ("Already Executing");
		}
	}

	public void executeQueue() {
		if (playerCharacter.attackQueue.Count != 0) {
			currentAttack = playerCharacter.attackQueue.Peek ();
			if (playerCharacter.Energy > currentAttack.Cost) {
//				for (int i = 1; i < attackImage.Count; i++) {
//					attackImage [i].transform.localPosition -= new Vector3(attackImage[0].GetComponent<RectTransform>().rect.width, 0, 0);
//				}
//				Destroy (attackImage [0]);
//				attackImage.RemoveAt (0);
				playerCharacter.Executing = true;
				playerCharacter.executeQueue ();
			} else {
				playerCharacter.Executing = false;
				Debug.Log ("Not enough energy for " + currentAttack.Name);
			}
		} else {
			playerCharacter.Executing = false;
			Debug.Log ("Queue is empty or executing");
		}
	}

	void placeAttackIcon(Attack attack) {
		int count = attackImage.Count;
		attackImage.Add (Instantiate (Resources.Load ("AttackIcon") as GameObject));
		attackImage [count].GetComponentInChildren<Text> ().text = attack.Name;
		attackImage [count].GetComponent<RectTransform> ().sizeDelta = new Vector2 ((energyBar.GetComponent<RectTransform> ().rect.width / playerCharacter.MaxQueueSize) * ((float)attack.Cost / 100), 30);
		attackImage [count].transform.SetParent (GameObject.Find ("Energy Bar").transform);
		attackImage [count].transform.localPosition = Vector2.zero;
		if (count == 0) {
			attackImage [count].transform.localPosition = new Vector2 (attackImage [count].GetComponent<RectTransform> ().rect.width * playerCharacter.attackQueue.Count - GameObject.Find ("Energy Bar").GetComponent<RectTransform> ().rect.width / 2 - attackImage [count].GetComponent<RectTransform> ().rect.width / 2, 50);
		} else {
			attackImage [count].transform.localPosition = new Vector2 ((attackImage [count - 1].transform.localPosition.x + attackImage [count - 1].GetComponent<RectTransform> ().rect.width / 2) + (attackImage[count].GetComponent<RectTransform>().rect.width / 2), 50);
	
		}
	}

	public void iconTesting() {
		for (int i = 1; i < attackImage.Count; i++) {
			attackImage [i].transform.localPosition -= new Vector3(attackImage[0].GetComponent<RectTransform>().rect.width, 0, 0);
		}
		Destroy (attackImage [0]);
		attackImage.RemoveAt (0);
		playerCharacter.Energy -= currentAttack.Cost;
		playerCharacter.CurrentQueueSize -= currentAttack.Cost;
	}

	void endBattle() {
		enemy.transform.parent.gameObject.GetComponent<ZoneSpawner> ().zoneEnemies.Remove (enemy);
		Destroy (enemy);
		this.GetComponent<EnemySelection> ().playerControllerStatus (true);
		//		SceneManager.LoadScene ("Overworld");
//		player.transform.position = this.GetComponent<EnemySelection>().playerWorldLocation;
//		player.transform.rotation = this.GetComponent<EnemySelection>().playerWorldRotation;

		player.transform.position = GameObject.Find("GameManager").GetComponent<GameController>().playerWorldLocation;
		player.transform.rotation = GameObject.Find("GameManager").GetComponent<GameController>().playerWorldRotation;

		playerCharacter.attackQueue.Clear ();
		playerCharacter.Executing = false;
		playerCharacter.resetStats ();
		SceneManager.LoadScene ("Post Battle");
	}

	public void Flee() {
		playerCharacter.BattleOutcome = "flee";
		playerCharacter.GoldToAdd = 0;
		playerCharacter.ExperienceToAdd = 0;
		endBattle ();
	}

	void Victory() {
		playerCharacter.BattleOutcome = "victory";
		playerCharacter.GoldToAdd += playerEnemy.Level * 40;
		playerCharacter.ExperienceToAdd = (int) (Mathf.Sqrt (playerEnemy.Level * 1000));
		endBattle ();
	}

	void Defeat() {
		playerCharacter.BattleOutcome = "defeat";
		playerCharacter.GoldToAdd = playerEnemy.Level * 40;
		playerCharacter.ExperienceToAdd = 0;
		endBattle ();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {

//	public GameObject enemy;
	GameController gameController;
	GameObject characterViewerCanvas;
	Character character;
	GameObject minimapCamera;
	GameObject minimapCanvas;
//	public float spawnTime = 10f;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameManager").GetComponent<GameController> ();
		characterViewerCanvas = GameObject.Find ("CharacterViewer Canvas");
		character = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().character;
		minimapCamera = GameObject.Find ("Minimap Camera");
		minimapCanvas = GameObject.Find ("Minimap Canvas");
		characterViewerCanvas.SetActive (false);
		foreach(GameObject enemy in gameController.enemies){
			enemy.SetActive (true);
			enemy.GetComponent<NavMeshAgent> ().enabled = true;
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			CharacterViewer ();
		}
	}

	public void CharacterViewer () {
		characterViewerCanvas.SetActive (!characterViewerCanvas.activeSelf);
		minimapCamera.SetActive (!minimapCamera.activeSelf);
		minimapCanvas.SetActive (!minimapCanvas.activeSelf);
		if (characterViewerCanvas.activeSelf) {
			MusicPlayer.PlayGameMenuMusic ();
			Time.timeScale = 0;
			GameObject.Find ("Character Name").GetComponentInChildren<Text> ().text = character.CharacterType;
			GameObject.Find ("HealthImage").GetComponentInChildren<Text> ().text = character.CurrentHealth + "/" + character.MaxHealth;
			GameObject.Find("HealthBar").GetComponent<EnergyBar>().valueCurrent = (int)((double)character.CurrentHealth / (double)character.MaxHealth * 100);
			GameObject.Find ("DamageImage").GetComponentInChildren<Text> ().text = "Damage: " + character.Damage + "x";
			GameObject.Find ("DefenseImage").GetComponentInChildren<Text> ().text = "Defense: " + character.Defense + "%";
			GameObject.Find ("CriticalHitImage").GetComponentInChildren<Text> ().text = "Critical Hit: " + character.CriticalPercentage + "%";
			GameObject.Find ("MissImage").GetComponentInChildren<Text> ().text = "Miss: " + character.MissPercentage + "%";
			GameObject.Find ("AttackOneImage").GetComponentInChildren<Text> ().text = character.attackOne.Name;
			GameObject.Find ("AttackTwoImage").GetComponentInChildren<Text> ().text = character.attackTwo.Name;
			GameObject.Find ("AttackThreeImage").GetComponentInChildren<Text> ().text = character.attackThree.Name;
			GameObject.Find ("AttackFourImage").GetComponentInChildren<Text> ().text = character.attackFour.Name;
			GameObject.Find("ExperienceText").GetComponent<Text>().text = "XP: " + character.Experience.ToString() + "/" + (character.Level * 20).ToString();
			GameObject.Find ("ExperienceBar").GetComponent<EnergyBar> ().valueMax = character.Level * 20;
			GameObject.Find("ExperienceBar").GetComponent<EnergyBar>().valueCurrent = character.Experience;
			GameObject.Find ("LevelImage").GetComponentInChildren<Text> ().text = "Lv. " + character.Level.ToString();
			GameObject.Find ("NextLevelImage").GetComponentInChildren<Text> ().text = "Lv. " + (character.Level + 1).ToString();
		} else {
			MusicPlayer.PlayOverworldMusic ();
			Time.timeScale = 1;
		}
	}

	public void SaveGame() {
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().SaveGame ();
	}

	public void QuitGame() {
		Application.Quit ();
	}
}

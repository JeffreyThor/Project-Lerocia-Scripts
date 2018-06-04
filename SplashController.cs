using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {

	private GameObject player;
	GameController gameController;


	// Use this for initialization
	void Start () {
//		player = GameObject.FindGameObjectWithTag ("Player");
//		player.SetActive(false);
		gameController = GameObject.Find("GameManager").GetComponent<GameController> ();
//		SceneManager.LoadScene ("Overworld", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WarriorButtonPressed() {
		MusicPlayer.PlayStartGameSound ();
		SceneManager.LoadScene ("Overworld");
		MusicPlayer.PlayOverworldMusic ();
//		player.SetActive (true);
//		if (player == null) {
//			Debug.Log ("player is null");
//		}
//		player.tag = "Player";
		player = Instantiate(Resources.Load("Warrior") as GameObject);
		player.GetComponent<Player> ().CreateWarrior();
//		player.AddComponent<Warrior> ();
		DontDestroyOnLoad (player);
		foreach (GameObject spawner in gameController.spawners) {
			Instantiate (spawner);
		}
	}

	public void WizardButtonPressed() {
		MusicPlayer.PlayStartGameSound ();
		SceneManager.LoadScene ("Overworld");
		MusicPlayer.PlayOverworldMusic ();
		//		player.SetActive (true);
		//		if (player == null) {
		//			Debug.Log ("player is null");
		//		}
		//		player.tag = "Player";
		player = Instantiate(Resources.Load("Wizard") as GameObject);
		player.GetComponent<Player> ().CreateWizard();
		//		player.AddComponent<Warrior> ();
		DontDestroyOnLoad (player);
		foreach (GameObject spawner in gameController.spawners) {
			Instantiate (spawner);
		}
	}

	public void LooterButtonPressed() {
		MusicPlayer.PlayStartGameSound ();
		SceneManager.LoadScene ("Overworld");
		MusicPlayer.PlayOverworldMusic ();
		//		player.SetActive (true);
		//		if (player == null) {
		//			Debug.Log ("player is null");
		//		}
		//		player.tag = "Player";
		player = Instantiate(Resources.Load("Looter") as GameObject);
		player.GetComponent<Player> ().CreateLooter();
		//		player.AddComponent<Warrior> ();
		DontDestroyOnLoad (player);
		foreach (GameObject spawner in gameController.spawners) {
			Instantiate (spawner);
		}
	}

	public void LoadButtonPressed() {
		string characterType = PlayerPrefs.GetString ("CharacterType");
		int level = PlayerPrefs.GetInt ("Level");
		int currentHealth = PlayerPrefs.GetInt ("CurrentHealth");
		int maxHealth = PlayerPrefs.GetInt ("MaxHealth");
		int experience = PlayerPrefs.GetInt ("Experience");
		int gold = PlayerPrefs.GetInt ("Gold");

		if (characterType == "Warrior") {
			WarriorButtonPressed ();
		} else if (characterType == "Wizard") {
			WizardButtonPressed ();
		} else if (characterType == "Looter") {
			LooterButtonPressed ();
		} else {
			Debug.Log ("Load Error");
		}

		player.GetComponent<Player> ().character.loadGame (level, currentHealth, maxHealth, experience, gold);
		player.GetComponent<Player> ().LoadGame ();
	}

	public void QuitButtonPressed() {
		Application.Quit ();
	}
}

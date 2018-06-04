using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostBattleManager : MonoBehaviour {

	GameObject player;
	Character playerCharacter;
	GameObject victoryImage;
	GameObject experienceImage;
	GameObject goldImage;
	GameObject levelImage;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player.SetActive (false);
		playerCharacter = player.GetComponent<Player> ().character;
		MusicPlayer.PlayPostBattleMusic ();

		victoryImage = GameObject.Find ("VictoryImage");
		experienceImage = GameObject.Find ("ExperienceImage");
		goldImage = GameObject.Find ("GoldImage");
		levelImage = GameObject.Find ("LevelImage");

		experienceImage.GetComponentInChildren<Text> ().text = "XP: " + playerCharacter.ExperienceToAdd;
		playerCharacter.addExperience ();

		if (playerCharacter.BattleOutcome == "victory") {
			victoryImage.GetComponentInChildren<Text> ().text = "VICTORY!";
			goldImage.GetComponentInChildren<Text> ().text = "Gold: " + playerCharacter.GoldToAdd;
			playerCharacter.addGold ();
		} else if (playerCharacter.BattleOutcome == "defeat") {
			victoryImage.GetComponentInChildren<Text> ().text = "DEFEAT!";
			goldImage.GetComponentInChildren<Text> ().text = "Gold: -" + playerCharacter.GoldToAdd;
			playerCharacter.removeGold ();
		} else if (playerCharacter.BattleOutcome == "flee") {
			victoryImage.GetComponentInChildren<Text> ().text = "ESCAPED";
			goldImage.GetComponentInChildren<Text> ().text = "Gold: " + playerCharacter.GoldToAdd;
			playerCharacter.removeGold ();
		} else {
			victoryImage.GetComponentInChildren<Text> ().text = "ERROR";
			Debug.Log ("Conditional Error");
		}

		levelImage.GetComponentInChildren<Text> ().text = "Level: " + player.GetComponent<Player>().character.Level;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ContinuePressed() {
		if (playerCharacter.BattleOutcome == "defeat") {
			Destroy (player);
			foreach (GameObject spawner in  GameObject.Find("GameManager").GetComponent<GameController> ().spawners) {
				Destroy (spawner);
			}
			Destroy (GameObject.Find ("GameManager"));
			SceneManager.LoadScene ("Splash Scene");
			MusicPlayer.PlayMenuMusic ();
		} else {
			SceneManager.LoadScene ("Overworld");
			player.SetActive (true);
		}
	}
}

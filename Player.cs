using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Character character;
	public Enemy enemy;
	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateWarrior() {
		character = new Warrior ("Warrior", 1);
	}

	public void CreateWizard() {
		character = new Wizard ("Wizard", 1);
	}

	public void CreateLooter() {
		character = new Looter ("Looter", 1);
	}

	public void CreateEnemy(string enemyType, int level) {
		if (enemyType == "SkeletonFootman") {
			enemy = new SkeletonFootman (enemyType, level);
		}
		if (enemyType == "SkeletonArcher") {
			enemy = new SkeletonArcher (enemyType, level);
		}
		if (enemyType == "SkeletonSorcerer") {
			enemy = new SkeletonSorcerer (enemyType, level);
		}
		if (enemyType == "SkeletonWarlord") {
			enemy = new SkeletonWarlord (enemyType, level);
		}

		//TO-DO
		//Instance creation by string name

//		List<object> paramArray = new List<object> ();
//		paramArray.Add (enemyType);
//		paramArray.Add (level);
//
//		System.Activator.CreateInstance (type: GetType (enemyType), args:paramArray);
	}

	public void SaveGame() {
		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerPrefs.SetFloat ("PlayerX", player.transform.position.x);
		PlayerPrefs.SetFloat ("PlayerY", player.transform.position.y);
		PlayerPrefs.SetFloat ("PlayerZ", player.transform.position.z);

		character.SaveGame ();
	}

	public void LoadGame() {
		player = GameObject.FindGameObjectWithTag ("Player");
		float x = PlayerPrefs.GetFloat ("PlayerX");
		float y = PlayerPrefs.GetFloat ("PlayerY");
		float z = PlayerPrefs.GetFloat ("PlayerZ");

		player.transform.position = new Vector3 (x, y, x);
	}
}

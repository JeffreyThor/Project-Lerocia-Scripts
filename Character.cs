using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public string CharacterType{ get; set; }
	public int Level{ get; set; }
	public int CurrentHealth{  get; set; }
	public int MaxHealth{  get; set; }
	public double Damage{ get; set; }
	public double MaxDamage{ get; set; }
	public int Defense{ get; set; } // This is used as a percentage
	public int MaxDefense{ get; set; }
	public int Energy{ get; set; }
	public int EnergyFillRate{ get; set; }
	public int CurrentQueueSize{ get; set; }
	public int MaxQueueSize{ get; set; }
	public int CriticalPercentage{ get; set; } // This is used as a percentage
	public int MaxCriticalPercentage{ get; set; }
	public int MissPercentage{ get; set; } // This is used as a percentage
	public int MaxMissPercentage{ get; set; }
	public int Experience{ get; set; }
	public double ExperienceMultiplier{ get; set; }
	public int Gold{ get; set; }
	public double GoldMultiplier{ get; set; }
	public bool Executing{ get; set; }
	public int GoldToAdd{ get; set; }
	public int ExperienceToAdd{ get; set; }
	public string BattleOutcome{ get; set; }
	public Queue<Attack> attackQueue;
	public Attack attackOne;
	public Attack attackTwo;
	public Attack attackThree;
	public Attack attackFour;
	Attack currentAttack;
	IEnumerator coroutine;

	public Character(string characterType, int level) {
		this.CharacterType = characterType;
		this.Level = level;
		Energy = 0;
		EnergyFillRate = 1;
		Experience = 0;
		Gold = 0;
		Executing = false;
		attackQueue = new Queue<Attack> ();
	}

	public void queueAttack(Attack attack) {
		Debug.Log ("Queue attack " + attack.Name);
		CurrentQueueSize += attack.Cost;
		attackQueue.Enqueue (attack);
	}
		
	public void executeQueue() {
		currentAttack = attackQueue.Dequeue ();
		coroutine = currentAttack.executeAttack ();
//		Energy -= currentAttack.Cost;
//		CurrentQueueSize -= currentAttack.Cost;
		GameObject.Find ("BattleSystem").GetComponent<BattleController> ().StartCoroutine (coroutine);
//		currentAttack.executeAttack ();
	}

	public void levelUp() {
		Debug.Log ("Level Up!");
		Experience -= Level * 20;
		Level++;
		MaxHealth += Level * 20;
		CurrentHealth = MaxHealth;
	}

	public void resetStats() {
		Damage = MaxDamage;
		Defense = MaxDefense;
		MissPercentage = MaxMissPercentage;
		CriticalPercentage = MaxCriticalPercentage;
	}

	public void takeDamage(ref int damage) {
		damage = (int)(damage / ((float)Defense / 100));
		CurrentHealth -= damage;
	}

	public void gainHealth(int health) {
		CurrentHealth += health;
		if (CurrentHealth > MaxHealth) {
			CurrentHealth = MaxHealth;
		}
	}

	public void addGold() {
		Gold += (int) (GoldToAdd * GoldMultiplier);
		GoldToAdd = 0;
	}

	public void removeGold() {
		Gold -= GoldToAdd;
		GoldToAdd = 0;
	}

	public void addExperience() {
		Experience += (int) (ExperienceToAdd * ExperienceMultiplier);
		while (Experience >= Level * 20) {
			levelUp ();
		}
	}

	public void SaveGame() {
		PlayerPrefs.SetString ("CharacterType", CharacterType);
		PlayerPrefs.SetInt ("Level", Level);
		PlayerPrefs.SetInt ("CurrentHealth", CurrentHealth);
		PlayerPrefs.SetInt ("MaxHealth", MaxHealth);
		PlayerPrefs.SetInt ("Experience", Experience);
		PlayerPrefs.SetInt ("Gold", Gold);
	}

	public void loadGame(int level, int currentHealth, int maxHealth, int experience, int gold) {
		Level = level;
		CurrentHealth = currentHealth;
		MaxHealth = maxHealth;
		Experience = experience;
		Gold = gold;
	}
}

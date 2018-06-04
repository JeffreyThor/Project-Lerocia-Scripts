using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

	private static FloatingText popupText;
	private static GameObject parentObject;

	public static void CreateFloatingEnemyText(string text) {
		parentObject = GameObject.Find ("BattleSystem").GetComponent<BattleController> ().enemyHealthBar;
		popupText = Resources.Load<FloatingText> ("PopupTextParent");
		FloatingText instance = Instantiate (popupText);
		instance.transform.SetParent (parentObject.transform, false);
		instance.SetText (text);
	}

}

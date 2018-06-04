using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] spawners;

	public Vector3 playerWorldLocation;
	public Quaternion playerWorldRotation;

	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
//		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnMouseEnter() {
//		Debug.Log ("Mouse Enter");
//		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
//	}
//
//	void OnMouseExit() {
//		Debug.Log ("Mouse Exit");
//		Cursor.SetCursor (null, Vector2.zero, cursorMode);
//	}
}

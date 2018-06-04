using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

	Transform target;
	float storedShadowDistance;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, transform.position.y, target.position.z);
	}

	void OnPreRender () {
		storedShadowDistance = QualitySettings.shadowDistance;
		QualitySettings.shadowDistance = 0;
	}


	void OnPostRender () {
		QualitySettings.shadowDistance = storedShadowDistance;
	}
}

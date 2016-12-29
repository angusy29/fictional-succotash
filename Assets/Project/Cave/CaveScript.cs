using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScript : MonoBehaviour {

	public GameObject caveEnterUI;

	// Use this for initialization
	void Start () {
		caveEnterUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		caveEnterUI.SetActive (true);
	}

	void OnTriggerExit(Collider other) {
		caveEnterUI.SetActive (false);
	}
}

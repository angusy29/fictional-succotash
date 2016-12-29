using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveScript : MonoBehaviour {

	public GameObject caveEnterUI;
	public GameObject actionButton;

	// private Color lightOrange = new Color (0.96f, 0.77f, 0.42f);
	private Color lightBlue = new Color(0.5f, 0.8f, 1.0f);

	public Color lerpedColor;

	// Use this for initialization
	void Start () {
		caveEnterUI.SetActive (false);
		lerpedColor = lightBlue;
	}

	// Update is called once per frame
	void Update () {
		if (caveEnterUI.activeSelf) {
			lerpedColor = Color.Lerp (Color.white, lightBlue, Mathf.PingPong (Time.time, 1));
			actionButton.GetComponent<RawImage> ().color = lerpedColor;
		}
	}

	void OnTriggerEnter(Collider other) {
		caveEnterUI.SetActive (true);
	}

	void OnTriggerExit(Collider other) {
		caveEnterUI.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaveScript : MonoBehaviour {

	public GameObject caveEnterUI;
	// public GameObject actionButton;
	// public GameObject caveNameText;

	private GameObject userInterfaceLabel;	// this is the actual label that user sees

	// private Color lightOrange = new Color (0.96f, 0.77f, 0.42f);
	private Color lightBlue = new Color(0.5f, 0.8f, 1.0f);

	public Color lerpedColor;

	// Use this for initialization
	void Start () {
		userInterfaceLabel = (GameObject)Instantiate (caveEnterUI);

		lerpedColor = lightBlue;
		print (this.name);

		userInterfaceLabel.transform.FindChild ("CaveName").GetComponent<Text> ().text = this.name;

		userInterfaceLabel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (userInterfaceLabel.activeSelf) {
			lerpedColor = Color.Lerp (Color.white, lightBlue, Mathf.PingPong (Time.time, 1));
			// actionButton.GetComponent<RawImage> ().color = lerpedColor;

			userInterfaceLabel.transform.FindChild ("ActionButton").GetComponent<RawImage> ().color = lerpedColor;
		
			if (Input.GetKeyDown (KeyCode.E)) {
				print ("User entered cave!");
				SceneManager.LoadScene ("Scenes/" + this.name);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		userInterfaceLabel.SetActive (true);
	}

	void OnTriggerExit(Collider other) {
		userInterfaceLabel.SetActive (false);
	}
}

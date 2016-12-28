using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public GameObject fpsController;
	// because the healthbar UI is split into 2 bars
	public GameObject rightHealth;
	public GameObject leftHealth;
	public GameObject healthText;

	public float maxHealth = 700.0f;
	private float leftCurrentHealth;	// 0.36 of 700
	private float rightCurrentHealth;	// 0.64 of 700

	private float rightMaxHealth;
	private float leftMaxHealth;

	private float currentHealth;

	private float WARNING_HEALTH;
	private float CRITICAL_HEALTH;

	private int numFramesToSkip = 0;

	// Use this for initialization
	void Start () {
		WARNING_HEALTH = (float) 0.5 * maxHealth;
		CRITICAL_HEALTH = (float) 0.15 * maxHealth;

		rightHealth.transform.localScale = new Vector3(1, 1, 1);
		leftHealth.transform.localScale = new Vector3(1, 1, 1);

		currentHealth = leftCurrentHealth + rightCurrentHealth;

		rightMaxHealth = (float) 0.64 * 700;
		leftMaxHealth = (float) 0.36 * 700;
		leftCurrentHealth = leftMaxHealth;
		rightCurrentHealth = rightMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = leftCurrentHealth + rightCurrentHealth;

		// green
		if (currentHealth > WARNING_HEALTH) {
			rightHealth.GetComponent<Image> ().color = new Color (0.16f, 0.54f, 0.09f, 1f);
			leftHealth.GetComponent<Image> ().color = new Color (0.16f, 0.54f, 0.09f, 1f);
		}

		// warning hp, less than 50%, yellow
		if (currentHealth <= WARNING_HEALTH) {
			rightHealth.GetComponent<Image> ().color = new Color (1f, 0.92f, 0.016f, 1f);
			leftHealth.GetComponent<Image> ().color = new Color (1f, 0.92f, 0.016f, 1f);
		}

		// critical
		if (currentHealth <= CRITICAL_HEALTH) {
			rightHealth.GetComponent<Image> ().color = new Color (1f, 0f, 0f);
			leftHealth.GetComponent<Image> ().color = new Color (1f, 0f, 0f);
		}

		rightHealth.transform.localScale = new Vector3(rightCurrentHealth/rightMaxHealth, 1, 1);
		leftHealth.transform.localScale = new Vector3(leftCurrentHealth/leftMaxHealth, 1, 1);

		healthText.GetComponent<Text> ().text = currentHealth + "/ " + maxHealth;

		if (fpsController.transform.GetChild(1).GetComponent<SwordScript>().getIsHiding()) {
			if (numFramesToSkip == 10) {
				regenHealth ();
				numFramesToSkip = 0;
			}
			numFramesToSkip++;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "EnemyWeapon") {
			if (rightCurrentHealth >= 0) {
				rightCurrentHealth -= Random.Range (10, 30);
			} else {
				leftCurrentHealth -= Random.Range (10, 30);
			}

			rightCurrentHealth = Mathf.Round(rightCurrentHealth);
			leftCurrentHealth = Mathf.Round (leftCurrentHealth);

			// if rightCurrentHealth goes under 0, then we 
			// need to add it to leftCurrentHealth, because we took that damage
			if (rightCurrentHealth < 0) {
				leftCurrentHealth += rightCurrentHealth;
				rightCurrentHealth = 0;
			}

		}
	}

	void regenHealth() {
		if (currentHealth == maxHealth) {
			return;
		}

		if (leftCurrentHealth < leftMaxHealth) {
			leftCurrentHealth += 1.0f;
		} else {
			rightCurrentHealth += 1.0f;
		}
	}
}

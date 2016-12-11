using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public GameObject player;
	// because the healthbar UI is split into 2 bars
	private GameObject rightHealth;
	private GameObject leftHealth;
	public GameObject healthText;

	public float maxHealth = 700.0f;
	private float leftCurrentHealth;	// 0.36 of 700
	private float rightCurrentHealth;	// 0.64 of 700

	private float rightMaxHealth;
	private float leftMaxHealth;

	private float currentHealth;

	// Use this for initialization
	void Start () {
		rightHealth = player.transform.GetChild (2).FindChild("HealthBar").FindChild("HealthRight").gameObject;
		rightHealth.transform.localScale = new Vector3(1, 1, 1);

		leftHealth = player.transform.GetChild (2).FindChild("HealthBar").FindChild("HealthLeft").gameObject;
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

		rightHealth.transform.localScale = new Vector3(rightCurrentHealth/rightMaxHealth, 1, 1);
		leftHealth.transform.localScale = new Vector3(leftCurrentHealth/leftMaxHealth, 1, 1);

		healthText.GetComponent<Text> ().text = currentHealth + "/ " + maxHealth;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "EnemyWeapon") {
			if (rightCurrentHealth >= 0) {
				rightCurrentHealth -= Random.Range (10, 30);
			} else {
				leftCurrentHealth -= Random.Range (10, 30);
			}

			// if rightCurrentHealth goes under 0, then we 
			// need to add it to leftCurrentHealth, because we took that damage
			if (rightCurrentHealth < 0) {
				leftCurrentHealth += rightCurrentHealth;
				rightCurrentHealth = 0;
			}

		}
	}
}

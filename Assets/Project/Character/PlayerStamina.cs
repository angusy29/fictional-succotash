using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStamina : MonoBehaviour {
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	public GameObject staminaObject;
	public GameObject fpsController;

	private SwordScript playerSword;

	private float maxStamina;
	private float stamina;

	private int currFrame;

	private bool isAction; 		// did we do anything this frame

	public float RUN_SPEED;
	public float WALK_SPEED;

	private float ATTACK_STAMINA_COST = 1;
	private float RUN_STAMINA_COST = 1;

	private bool staminaIsDrained;

	// Use this for initialization
	void Start () {
		staminaObject.transform.localScale = new Vector3 (1, 1, 1);
		playerSword = fpsController.transform.GetChild(1).GetComponent<SwordScript> ();

		maxStamina = 100.0f;
		stamina = maxStamina;

		currFrame = 0;

		isAction = false;
		staminaIsDrained = false;
	}
	
	// Update is called once per frame
	void Update () {
		staminaObject.transform.localScale = new Vector3 ((float) (stamina / maxStamina), 1, 1);
		isAction = false;

		if (stamina == 0) {
			staminaIsDrained = true;
			controller.setRunSpeed (WALK_SPEED);
		}

		if (stamina == maxStamina) {
			staminaIsDrained = false;
		}

		if (!staminaIsDrained) {
			staminaObject.GetComponent<Image> ().color = new Color (0.07f, 0.37f, 0.95f);

			if (hasStaminaToRun()) {
				// user is running so decrease stamina
				if (Input.GetKey (KeyCode.LeftShift)) {
					controller.setRunSpeed (RUN_SPEED);
					stamina -= RUN_STAMINA_COST;
					isAction = true;
				}
			} else {
				controller.setRunSpeed (WALK_SPEED);
			}

			if (hasStaminaToAttack()) {
				if (playerSword.getIsSwinging ()) {
					stamina -= ATTACK_STAMINA_COST;
					isAction = true;
				}
			}
		}

		if (staminaIsDrained) {
			staminaObject.GetComponent<Image> ().color = new Color (1f, 0f, 0f);
		}

		if (!isAction && stamina < maxStamina) {
			regenStamina ();
		}
	}

	// regenerate stamina every frame
	void regenStamina() {
		stamina += 1;
	}

	public float getStamina() {
		return stamina;
	}

	public bool getStaminaIsDrained() {
		return staminaIsDrained;
	}

	public bool hasStaminaToAttack() {
		if (stamina > ATTACK_STAMINA_COST - 1) {
			return true;
		}
		return false;
	}

	public bool hasStaminaToRun() {
		if (stamina > RUN_STAMINA_COST - 1) {
			return true;
		}
		return false;
	}
}

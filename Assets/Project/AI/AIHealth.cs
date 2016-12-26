using UnityEngine;
using System.Collections;

public class AIHealth : MonoBehaviour {
	
	public GameObject thisAI;
	private GameObject healthBar;
	public float maxHealth = 500.0f;
	public float currentHealth = 0.0f;

	private bool isDead;
	private Animation anim;
	private Vector3 playerPos;

	private float DEATH_TIME = 3.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		currentHealth = maxHealth;

		isDead = false;

		healthBar = thisAI.transform.GetChild (5).FindChild("Health").gameObject;
		healthBar.transform.localScale = new Vector3(1, 1, 1);

		playerPos = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;

		if (currentHealth <= 0) {
			isDead = true;
			anim.Play ("death");
			Destroy (thisAI, DEATH_TIME);
			return;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" && SwordScript.getIsSwinging()) {
			currentHealth -= Random.Range (45, 65);
			currentHealth = Mathf.Round (currentHealth);

			if (currentHealth <= 0) {
				healthBar.transform.localScale = new Vector3 (0, 1, 1);
			} else {
				healthBar.transform.localScale = new Vector3 ((float) (currentHealth/maxHealth), 1, 1);
			}
		}
	}

	public float getCurrentHealth() {
		return currentHealth;
	}

	public bool getIsDead() {
		return isDead;
	}
}

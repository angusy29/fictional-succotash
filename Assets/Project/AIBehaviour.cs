using UnityEngine;
using System.Collections;

public class AIBehaviour : MonoBehaviour {

	public GameObject thisAI;
	public float aggroDist;
	public float speed;
	public float rotationSpeed;

	private Vector3 myPos;
	private Vector3 playerPos;
	private Animation anim;

	private float attackDist;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		attackDist = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (thisAI.GetComponent<AIHealth> ().getIsDead ())
			return;

		myPos = transform.position;
		playerPos = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;

		if (Vector3.Distance (myPos, playerPos) < attackDist) {
			anim.Play ("attack2");
		} else if (Vector3.Distance (myPos, playerPos) < aggroDist) {
			transform.rotation = Quaternion.Slerp (transform.rotation, 
				Quaternion.LookRotation (playerPos - transform.position), 
				rotationSpeed * Time.deltaTime);

			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, playerPos, step);

			float yVal = Terrain.activeTerrain.SampleHeight (new Vector3 (transform.position.x, 0.0f, transform.position.z));

			transform.position = new Vector3 (transform.position.x, yVal, transform.position.z);

			anim.Play ("run");
		} else {
			anim.Play ("combat_idle");
		}
	}
}

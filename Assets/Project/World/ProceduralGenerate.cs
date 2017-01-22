using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {
	public GameObject startPlatform;
	public GameObject corridor;
	public GameObject junction;
	public GameObject link;
	public GameObject room;
	public GameObject slope;

	public int numIterations;

	private List<GameObject> platforms_;	// keeps track of available prefabs
	private GameObject currPlatform_;		// keeps track of the current platform

	// Use this for initialization
	void Start () {
		platforms_ = new List<GameObject> ();
		platforms_.Add (corridor);
		platforms_.Add (junction);
		platforms_.Add (link);
		platforms_.Add (room);
		platforms_.Add (slope);

		currPlatform_ = startPlatform;

		for (int i = 0; i < numIterations; i++) {
			currPlatform_ = GenerateDungeon (currPlatform_);
		}
	}

	// adds one platform to the dungeon and returns the new platform
	GameObject GenerateDungeon(GameObject currPlatform) {

		// pick a random exit of the current platform
		Transform exit = currPlatform.transform;	// for now just pick the first exit
		foreach (Transform child in currPlatform.transform) {
			if (child.CompareTag ("Exit")) {
				exit = child;
			}
		}

		// instantiate a new gameobject
		int randIndex = Random.Range (0, platforms_.Count);
		// randomly rotate the object
		currPlatform = (GameObject) Instantiate (platforms_[randIndex], new Vector3(exit.position.x, exit.position.y, exit.position.z), Quaternion.identity);

		// change current platform

		return currPlatform;
	}
	
	// Update is called once per frame
	/* void Update () {
		
	} */
}

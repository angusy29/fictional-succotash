using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {
	public GameObject startPlatform;
	public GameObject corridor;
	public GameObject junction;
	public GameObject link;
	public GameObject room;
	public GameObject upSlope;
	public GameObject downSlope;

	public int numIterations;

	private List<GameObject> platforms_;	// keeps track of available prefabs
	// private GameObject currPlatform_;		// keeps track of the current platform

	private List<GameObject> instantiatedPlatforms_;	// keeps track of all the instantiatedPlatforms

	// Use this for initialization
	void Start () {
		platforms_ = new List<GameObject> ();
		platforms_.Add (corridor);
		platforms_.Add (junction);
		platforms_.Add (link);
		platforms_.Add (room);
		platforms_.Add (upSlope);
		platforms_.Add (downSlope);

		instantiatedPlatforms_ = new List<GameObject> ();

		// currPlatform_ = startPlatform;
		instantiatedPlatforms_.Add(startPlatform);

		while (instantiatedPlatforms_.Count < numIterations) {
			createPlatform ();
		}
	}

	// adds one platform to the dungeon and returns the new platform
	void createPlatform() {
		// int randIndex = Random.Range (0, instantiatedPlatforms_.Count);
		int randIndex = instantiatedPlatforms_.Count - 1;
		// pick a random exit of the current platform
		Transform exit = instantiatedPlatforms_[randIndex].transform;	// for now just pick the first exit
		foreach (Transform child in instantiatedPlatforms_[randIndex].transform) {
			if (child.CompareTag ("Exit")) {
				exit = child;
			}
		}

		print (exit.name);

		// instantiate a new gameobject
		randIndex = Random.Range (0, platforms_.Count);

		//Quaternion rot = new Quaternion(exit.transform.eulerAngles.x, 180 - exit.transform.eulerAngles.y, exit.transform.eulerAngles.z, 0);
		print(exit.transform.eulerAngles);
		// randomly rotate the object
		GameObject platform = (GameObject) Instantiate (platforms_[randIndex], new Vector3(exit.position.x, exit.position.y, exit.position.z), Quaternion.identity);

		// translate the platform so an entrance is at the same coordinate as the exit
		Transform entrance = platform.transform;
		foreach (Transform child in platform.transform) {
			if (child.CompareTag ("Entrance")) {
				entrance = child;
			}
		}

		print (entrance.name);
		print (entrance.transform.eulerAngles);
		Vector3 toRotate = new Vector3(0.0f, 180 - exit.transform.eulerAngles.y, 0.0f);
		platform.transform.eulerAngles = toRotate;

		print (entrance.transform.eulerAngles);
		Vector3 vec = exit.position - entrance.position;
		platform.transform.Translate (vec);
		instantiatedPlatforms_.Add (platform);
	}
	
	// Update is called once per frame
	/* void Update () {
		
	} */
}

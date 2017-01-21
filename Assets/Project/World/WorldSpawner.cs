using UnityEngine;
using System.Collections;

// spawns numGoblins on the world map at random given x and z ranges
using System.Collections.Generic;


public class WorldSpawner : MonoBehaviour {
	public int numGoblins;
	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;

	public GameObject goblinPrefab;

	private List<GameObject> allGoblins_;

	// Use this for initialization
	void Start () {
		allGoblins_ = new List<GameObject> ();


		float yv = Terrain.activeTerrain.SampleHeight (new Vector3(410, 0, 140));
		allGoblins_.Add ((GameObject)Instantiate (goblinPrefab, new Vector3 (410, yv, 140), Quaternion.identity));

		for (int i = 0; i < numGoblins; i++) {
			float randX = Random.Range (minX, maxX);
			float randZ = Random.Range (minZ, maxZ);
			float y = Terrain.activeTerrain.SampleHeight (new Vector3(randX, 0, randZ));

			allGoblins_.Add((GameObject) Instantiate(goblinPrefab, new Vector3(randX, y, randZ), Quaternion.identity));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

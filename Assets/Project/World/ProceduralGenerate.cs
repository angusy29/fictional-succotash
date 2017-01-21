using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour {
	public GameObject corridor;
	public GameObject junction;
	public GameObject link;
	public GameObject room;
	public GameObject slope;

	private List<GameObject> platforms_;

	// Use this for initialization
	void Start () {
		platforms_ = new List<GameObject> ();
		platforms_.Add (corridor);
		platforms_.Add (junction);
		platforms_.Add (link);
		platforms_.Add (room);
		platforms_.Add (slope);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treepionizer : MonoBehaviour {

	// Use this for initialization
	public float distance = 8f;

	void Start () {
		//List<GameObject> trees = GameObject.FindGameObjectsWithTag("Trees")

			foreach (GameObject tree in GameObject.FindGameObjectsWithTag("Tree")) {
			tree.transform.localPosition = tree.transform.localPosition.normalized * distance;
			tree.transform.rotation = Quaternion.FromToRotation (tree.transform.up, tree.transform.localPosition) * tree.transform.rotation;

		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

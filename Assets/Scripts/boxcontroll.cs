using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcontroll : MonoBehaviour {


	public GameObject Planet;
	public GameObject Box;
	public float fr=20f;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > fr) {
			timer = timer - fr;
			Instantiate(Box,Planet.transform.position+((Random.rotationUniform * Vector3.forward) * 100f),Random.rotation);
		}
	}
}

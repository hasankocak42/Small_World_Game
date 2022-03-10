using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUp : MonoBehaviour {

	GameObject Planet;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		Planet = GameObject.FindGameObjectWithTag ("Planet");
		rb = gameObject.GetComponent<Rigidbody> ();

		//Debug.Log (Planet);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 Distance = new Vector3();
		//Distance=transform.position-Planet.transform.position;

		//Debug.DrawLine (transform.position, transform.position + transform.localPosition.normalized);
		transform.rotation = Quaternion.FromToRotation (transform.forward, transform.position - Planet.transform.position)*transform.rotation;

	}
}

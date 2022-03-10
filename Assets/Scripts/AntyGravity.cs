using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntyGravity : MonoBehaviour {

	float G = 1000;
	GameObject Planet;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		Planet = GameObject.FindGameObjectWithTag ("Planet");
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		Vector3 Distance = new Vector3();
		Distance=Planet.transform.position-rb.transform.position;
		//Debug.Log (Distance.magnitude);
		Vector3 Force = new Vector3 ();
		Force = Distance.normalized;
		Force = (Force * ((G * rb.mass) / (Distance.magnitude * Distance.magnitude)));
		rb.AddForce (-Force);
	}
}




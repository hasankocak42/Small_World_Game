using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : MonoBehaviour {
	public float speed = 2f;
	public float max_size = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = new Vector3 (1, 1, 1);
		temp = temp * speed * Time.deltaTime;
		transform.localScale = transform.localScale + temp;
		if (transform.localScale.x > max_size) {
			GameObject.Destroy (gameObject);
		}
	}
}

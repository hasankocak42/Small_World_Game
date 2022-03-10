using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization

	float timer;
	void Start () {
		gameObject.GetComponent<AudioSource> ().pitch = Random.Range (0.9f, 1.1f);
		timer = 5f;	
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer - Time.deltaTime;
		if (timer < 0)
			GameObject.Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Player")) {
			collision.gameObject.GetComponent<AudioSource> ().pitch = Random.Range (0.9f, 1.1f);
			collision.gameObject.GetComponent<AudioSource> ().Play();

			if (collision.gameObject.GetComponent<Player> ().live) {
				collision.gameObject.GetComponent<Player> ().RestoreHealth (50);
				GameObject.Destroy (gameObject);
			}
		}

		//Debug.Log (gameObject.transform.parent);
		if (gameObject.transform.parent == null ) {
			if (collision.gameObject.tag.Equals ("Planet")) {
				gameObject.transform.parent = collision.gameObject.transform;
			}
		}

	}

}

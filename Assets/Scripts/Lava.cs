using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	public float Speed = 0.1f;
	public float MinMag = 1;
	public float lavadamage = 50f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = transform.localPosition - (transform.localPosition.normalized * Speed * Time.deltaTime);

		if (transform.localPosition.magnitude < MinMag)
			GameObject.Destroy (gameObject);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals ("Player")) {
			other.gameObject.GetComponent<Player> ().TakeDamageLava (lavadamage * Time.deltaTime);
		}
	}
}

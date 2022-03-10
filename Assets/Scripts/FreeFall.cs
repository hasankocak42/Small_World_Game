using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour {
	static float G = 1000;
	GameObject Planet;
	Rigidbody rb;
	GameObject Explosion;
	GameObject Debrees;
	GameObject Lava;
	public bool explode = false;
	// Use this for initialization
	void Start () {
		Planet = GameObject.FindGameObjectWithTag ("Planet");
		rb = gameObject.GetComponent<Rigidbody> ();
		Explosion=GameObject.Find ("MeteorControll").GetComponent<MeteorController> ().Explosion;
		Lava=GameObject.Find ("MeteorControll").GetComponent<MeteorController> ().Lava;
		Debrees = GameObject.Find ("MeteorControll").GetComponent<MeteorController> ().Debrees;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 Distance = new Vector3();
		Distance=Planet.transform.position-rb.transform.position;
		//Debug.Log (Distance.magnitude);
		Vector3 Force = new Vector3 ();
		Force = Distance.normalized;
		Force = (Force * ((G * rb.mass) / (Distance.magnitude * Distance.magnitude)));
		rb.AddForce (Force);



		if (explode == true) {
			Color darkred = Color.Lerp(Color.black,Color.red,0.5f);
			Color emision;
			if (Distance.magnitude < 15) {
				if (Distance.magnitude > 11) {
					float scale = (Distance.magnitude - 11) / 4;
					emision = Color.Lerp ( darkred,Color.black, scale);
				} else {

					if (Distance.magnitude > 7) {
						float scale = (Distance.magnitude - 7) / 4;
						emision = Color.Lerp (Color.yellow,darkred, scale);
					} else {
						emision = Color.yellow;
					}
				}
			} else
				emision = Color.black;

			Material tempmat = gameObject.GetComponent<MeshRenderer> ().material;
			tempmat.SetColor ("_EmissionColor", emision);
		}

	}

	void OnCollisionEnter(Collision collision)
	{
		bool hitplayer = false;
		if (explode == false)
			return;
		

		if (collision.gameObject.tag.Equals ("Meteor"))
			return;

		if (collision.gameObject.tag.Equals ("GroundObject")) {
			//Instantiate (Debrees, collision.gameObject.transform.parent.position, Quaternion.identity);
			GameObject.Destroy (collision.gameObject.transform.parent.gameObject);
			Instantiate (Debrees, collision.contacts [0].point, Quaternion.identity);
			//return;
		}
			




		if (collision.gameObject.tag.Equals ("Player")) {
			collision.gameObject.GetComponent<Player> ().TakeDamage (100);
			hitplayer = true;
		} 

		Vector3 pusher = new Vector3 ();
		pusher = gameObject.transform.position;

		pusher = Vector3.Normalize (Planet.transform.position - pusher) + pusher;

		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 Distance = new Vector3 ();
		Distance =(Player.transform.position - pusher);
		//Debug.Log (Distance.magnitude);

		if (Distance.magnitude < 4f) {

			if(hitplayer==false) Player.GetComponent<Player> ().TakeDamage ((4 - Distance.magnitude)/4 * 50);


			Player.GetComponent<Rigidbody> ().AddForce (Distance.normalized * (4 - Distance.magnitude)/4 * 1000);

			//Debug.Log (Vector3.Magnitude(Distance.normalized * (4 - Distance.magnitude)/4* 100));
			//Debug.DrawLine (Player.transform.position, Player.transform.position + (Distance.normalized * (4 - Distance.magnitude)/4 * 1000));

			//Debug.DrawLine (Player.transform.position, Distance.normalized * (3 - Distance.magnitude) * (3 - Distance.magnitude)/9 * 10000);

			//Debug.Break ();
		}


		Instantiate (Explosion, collision.contacts [0].point, Quaternion.identity);
		GameObject lavainstance = Instantiate (Lava, collision.contacts [0].point, Random.rotation);

		lavainstance.transform.parent = Planet.transform;
		lavainstance.transform.localPosition = (lavainstance.transform.localPosition.normalized)*5f;

		GameObject.Destroy (gameObject);



	}


}

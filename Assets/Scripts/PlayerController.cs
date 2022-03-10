using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1f;
	public GameObject Nova; 
	GameObject Player;
	GameObject Planet;
	GameObject CameraHolderH;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Planet = GameObject.FindGameObjectWithTag ("Planet");
		CameraHolderH = GameObject.Find ("CameraHolderH");
	}
	
	// Update is called once per frame
	void Update () {

		if (Player.GetComponent<Player> ().live == false) {
			return;
		}
		/*
		Vector3 ToCenter = new Vector3 ();
		ToCenter = (Planet.transform.position - Player.transform.position);

		Vector3 xvel = new Vector3();
		xvel = Vector3.Cross (ToCenter, (Camera.main.transform.position + 100000 * Camera.main.transform.up)).normalized;

		Vector3 yvel = new Vector3();
		yvel = Vector3.Cross (ToCenter, (Camera.main.transform.position + 100000 * Camera.main.transform.right)).normalized;

		//Debug.DrawLine (Player.transform.position, Player.transform.position + xvel,Color.red);
		//Debug.DrawLine (Player.transform.position, Player.transform.position + yvel,Color.blue);


		*/


		Vector3 xvel = new Vector3();
		xvel = -CameraHolderH.transform.right;

		Vector3 yvel = new Vector3();
		yvel = -CameraHolderH.transform.up;

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical"); 
		Vector2 Controll = new Vector2(horizontal,vertical);


		if (Controll.magnitude > 1) {
			Controll.Normalize();
			horizontal = Controll.x;
			vertical = Controll.y;
		}

		if (horizontal != 0) {
			
			xvel.Normalize();
			//Debug.DrawLine (Player.transform.position,Player.transform.position+(xvel));

			Player.transform.Translate (-xvel* speed *Time.deltaTime*horizontal,Space.World);
		}
		if (vertical != 0) {

			yvel.Normalize();
			//Debug.DrawLine (Player.transform.position,Player.transform.position+(yvel));

			Player.transform.Translate (yvel* speed *Time.deltaTime*vertical,Space.World);
		}

		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	Instantiate (Nova, Player.transform.position, Quaternion.identity);
		//}
	}
}

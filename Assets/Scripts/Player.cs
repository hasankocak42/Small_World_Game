using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {

	public bool live = true;
	public bool ejected = false;
	public bool melted = false;

	public float Health = 100;
	float maxHealth = 100;

	public float Shields = 100;
	float maxShields = 100;

	public float ShieldsRegen = 5f;
	public int nova = 0;
	public int thunder = 0;

	public RectTransform Healthpannel;
	public RectTransform Shieldpannel;



	bool lavadamage;
	// Use this for initialization
	void Start () {

		lavadamage = false;
		live = true;
		ejected = false;
		melted = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (transform.localPosition.magnitude);

		Healthpannel.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 200 * Health / maxHealth);
		Shieldpannel.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 200 * Shields / maxShields);

		bool wasdamagedbylava = lavadamage;
		if (live) {

			if (gameObject.transform.localPosition.magnitude > 50) {
				ejected = true;
				live = false;
			}

			lavadamage = false;

			if (Health <= 0) {
				live = false;



			}
		}

		if (live&&(!wasdamagedbylava)) {
			Shields += ShieldsRegen * Time.deltaTime;
			if (Shields > maxShields)
				Shields = maxShields;
		}

		if (!live) {
			gameObject.GetComponent<StandUp> ().enabled = false;
			gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

			if (ejected == false) {
				GameObject.Find ("CameraHolderH").transform.parent = null;
			}
			GameObject.Find ("PlayerController").GetComponent<PlayerController> ().enabled = false;
		}


	}

	public void RestoreHealth(float hp)
	{
		Health = Health + hp;
		if (Health > maxHealth)
			Health = maxHealth;
	}

	public void RestoreShields(float sh)
	{
		Shields = Shields + sh;
		if (Shields > maxShields)
			Shields = maxShields;
	}

	public void TakeDamageLava(float damage)
	{
		if ((lavadamage == false) && (Health >0 )) {
			lavadamage = true;

			Shields = Shields - damage;
			if (Shields < 0) {
				Health += Shields;
				Shields = 0;
			}
			if (Health <= 0) {
				melted = true;
			}


		} else {
			return;
		}
	}

	public void TakeDamage(float damage)
	{


		Shields = Shields - damage;
		if (Shields < 0) {
			Health += Shields;
			Shields = 0;
		}


		
	}
}

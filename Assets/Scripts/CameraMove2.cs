using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour {

	public float ZoomPrecizion = 50f;
	public float ZoomMin = 0.3f;
	public float ZoomMax = 3f;

	GameObject Holder;
	GameObject Manager;
	Quaternion NewRot;
	// Use this for initialization
	void Start () {
		Manager = GameObject.Find ("Gamemanager");
		Holder=GameObject.Find("CameraHolderH");
		//	Goal = new Quaternion();
		//	Goal = transform.rotation;
	}

	// Update is called once per frame
	void Update () {

		if (Manager.GetComponent<Gamamanager> ().pause == true) {
			return;
		}

		//zoom
		if (Input.mouseScrollDelta.y!= 0) {
			Vector3 scale = transform.localScale;
			scale = scale * (1 + (Input.mouseScrollDelta.y / ZoomPrecizion));
			if (scale.x < ZoomMin) {
				scale.x = ZoomMin;
				scale.y = ZoomMin;
				scale.z = ZoomMin;
			}
			if (scale.x > ZoomMax) {
				scale.x = ZoomMax;
				scale.y = ZoomMax;
				scale.z = ZoomMax;
			}
			transform.localScale = scale;
		}
		//rotation
		if (Input.GetMouseButton (1)) {
			//Debug.Log (Holder.transform.rotation);
			Holder.transform.rotation = Holder.transform.rotation* Quaternion.Euler (0, 0, 5 * Input.GetAxis ("Mouse X"));
			//transform.rotation = transform.rotation* Quaternion.Euler (0, 5 * Input.GetAxis ("Mouse X"), 0);
			NewRot = transform.localRotation* Quaternion.Euler (-5 * Input.GetAxis ("Mouse Y"), 0, 0);



			if ((NewRot.eulerAngles.x > 0) && (NewRot.eulerAngles.x < 180)) {

				transform.localRotation = NewRot;
				
			}
		}
	}
}

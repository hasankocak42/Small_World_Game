using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float ZoomPrecizion = 50f;
	public float ZoomMin = 0.3f;
	public float ZoomMax = 3f;

	Quaternion Goal; 

	// Use this for initialization
	void Start () {
	//	Goal = new Quaternion();
	//	Goal = transform.rotation;
	}

	// Update is called once per frame
	void Update () {

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
			//Input.GetAxis ("Mouse X");
			transform.Rotate (new Vector3(0, 1, 0)*5*Input.GetAxis ("Mouse X"));
			transform.Rotate (new Vector3(1, 0, 0)*-5*Input.GetAxis ("Mouse Y"));
			//Vector3 rotation = new Vector3 ();
			//rotation=transform.rotation.eulerAngles;
			//transform.rotation=Quaternion.Euler(rotation.x,rotation.y,0);
			//Goal = Quaternion.RotateTowards(Goal,Quaternion.FromToRotation(Vector3.forward,Vector3.right), 1f);
			//Quaternion.Euler(new Vector3(0,1,0);
		}

		//transform.rotation=Quaternion.LerpUnclamped (transform.rotation, Goal, 0.5f);
	}
}

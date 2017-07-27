using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerPosition : MonoBehaviour {

	public Transform pointerTransform;
	public Transform playerTransform;
	public LayerMask mouseLocationLayer;
	public float pointerDistance = 1.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){


		/** Updates pointer position **/
		Vector3 pointerDir = Vector3.one;

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 9000, mouseLocationLayer.value))
			pointerDir = hit.point - playerTransform.position;

		pointerDir.y = playerTransform.position.y;
		pointerDir.Normalize ();
		pointerDir.Scale( new Vector3 (pointerDistance, pointerDistance, pointerDistance));
		pointerTransform.localPosition = pointerDir;


		/** Updates pointer rotation **/
		// When the vector is foward (0,0,1) the angle rotation of the pointer(y axis) must be zero, ando so on.
		Quaternion rot = pointerTransform.rotation;
		pointerDir.y = playerTransform.position.y;
		rot.SetLookRotation (pointerDir);
		pointerTransform.localRotation = rot;
		pointerTransform.Rotate (106, 0, 0);
	}
}

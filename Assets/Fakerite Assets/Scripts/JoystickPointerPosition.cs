using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPointerPosition : MonoBehaviour {

	public Transform pointerTransform;
	public Transform playerTransform;
	public int playerNumber = 1;
	public Vector3 pointerDir;
	public float pointerDistance = 1.2f;
	public bool keyboard = false;
	public LayerMask mouseLocationLayer;

	private Vector3 initialScale;
	private Vector3 pointerLastDir;


	// Use this for initialization
	void Start () {
		initialScale = pointerTransform.localScale;
		pointerDir = new Vector3(0, 0.35f, 1.15f); // that's an adapted foward vector
	}

	void FixedUpdate(){
		float horizontalAxis = 0.0f;
		float verticalAxis = 0.0f;

		/** Updates pointer position **/
		if (keyboard){
			Vector3 pointerDir = Vector3.one;

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 9000, mouseLocationLayer.value))
				pointerDir = hit.point - playerTransform.position;
			

			// normalize preserving signals
			pointerDir.x = pointerDir.x / 2*Mathf.Abs(pointerDir.x);
			pointerDir.z = pointerDir.z / 2*Mathf.Abs(pointerDir.z);
			horizontalAxis = pointerDir.x;
			verticalAxis = pointerDir.z;
			//Debug.Log (pointerDir);

		}else {
			/** Rigth = 0.5 **/
			/** Left = -0.5 **/
			horizontalAxis = Input.GetAxis ("RightHorizontal" + playerNumber);
			/** Up = 0.5 **/
			/** Down = -0.5 **/
			verticalAxis = Input.GetAxis ("RightVertical" + playerNumber);

		}
		/** Debug.Log ("Vertical Axis: " + verticalAxis);
		Debug.Log ("Horizontal Axis: " + horizontalAxis); **/

		float soma = Mathf.Abs (horizontalAxis) + Mathf.Abs (verticalAxis);

		if (soma < 1){
			horizontalAxis *= 100;
			verticalAxis *= 100;
		}

		//*dead* zone
		if (!(verticalAxis <= 0.5 && verticalAxis >= -0.5 && horizontalAxis <= 0.5 && horizontalAxis >= -0.5)){
			pointerTransform.localScale = initialScale;
			pointerDir = new Vector3 (horizontalAxis, playerTransform.position.y, verticalAxis);

			pointerDir.Normalize ();
			pointerDir.y = playerTransform.position.y;
			pointerDir.Scale(new Vector3 (pointerDistance, 1, pointerDistance));

		} else {
			pointerDir = new Vector3(0, 0.35f, 1.15f);
			pointerTransform.localScale = Vector3.zero;
		}

		pointerTransform.localPosition = pointerDir;

		/** Updates pointer rotation **/
		Quaternion rot = pointerTransform.rotation;
		rot.SetLookRotation (pointerDir);
		pointerTransform.localRotation = rot;
		pointerTransform.Rotate (106, 0, 0);
	}
}

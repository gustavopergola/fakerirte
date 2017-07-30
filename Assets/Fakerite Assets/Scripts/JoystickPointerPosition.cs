using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPointerPosition : MonoBehaviour {

	public Transform pointerTransform;
	public Transform playerTransform;
	public int playerNumber = 1;
	public Vector3 pointerDir;
	public float pointerDistance = 1.2f;

	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		initialScale = pointerTransform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		/** Updates pointer position **/
		float horizontalAxis = Input.GetAxis ("RightHorizontal" + playerNumber);
		float verticalAxis = Input.GetAxis ("RightVertical" + playerNumber);

		float soma = Mathf.Abs (horizontalAxis) + Mathf.Abs (verticalAxis);

		if (soma < 1){
			horizontalAxis *= 100;
			verticalAxis *= 100;
		}

		if ((verticalAxis == 0 && horizontalAxis == 0)){
			pointerTransform.localScale = new Vector3 (0, 0, 0);
		}else {
			pointerTransform.localScale = initialScale;
		}

		pointerDir = new Vector3 (horizontalAxis, playerTransform.position.y, verticalAxis);

		pointerDir.Normalize ();
		pointerDir.y = playerTransform.position.y;
		pointerDir.Scale(new Vector3 (pointerDistance, 1, pointerDistance));

		//Debug.Log ("pointerDir: " + pointerDir);

		pointerTransform.localPosition = pointerDir;

		/** Updates pointer rotation **/
		Quaternion rot = pointerTransform.rotation;
		rot.SetLookRotation (pointerDir);
		pointerTransform.localRotation = rot;
		pointerTransform.Rotate (106, 0, 0);
	}
}

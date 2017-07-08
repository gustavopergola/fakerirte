using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	private Rigidbody rigidbody;
	public float speed = 3;

	private float sqrt2;
	private bool isMovingVertical, isMovingHorizontal;
	// Use this for initialization
	void Start () {
		sqrt2 = Mathf.Sqrt (2f);
		rigidbody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newVelocity = new Vector3 (0, 0, 0);
		float horizontal = Input.GetAxis ("Horizontal");
		isMovingVertical = false;
		isMovingHorizontal = false;

		// 0.01 for a "dead" zone
		if (horizontal > 0.01){
			// move right
			newVelocity.x = speed * Time.deltaTime;
			isMovingHorizontal = true;
		}else if (horizontal < -0.01) {
			// move left
			newVelocity.x = -speed * Time.deltaTime;
			isMovingHorizontal = true;
		}

		float vertical = Input.GetAxis ("Vertical");
		// 0.01 for "dead zone
		if (vertical > 0.01){
			// move up
			newVelocity.z = speed * Time.deltaTime;
			isMovingVertical = true;
		}else if (vertical < -0.01) {
			// move down
			newVelocity.z = -speed * Time.deltaTime;
			isMovingVertical = true;
		}

		if (isMovingVertical && isMovingHorizontal){
			newVelocity = new Vector3(newVelocity.x / sqrt2, newVelocity.y / sqrt2, newVelocity.z / sqrt2);
		}
			

		rigidbody.velocity = newVelocity;

		Debug.Log ("Magnitude = " + rigidbody.velocity.magnitude);
	}

	void FixedUpdate(){
		
	}
}

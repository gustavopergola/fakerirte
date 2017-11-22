using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	private Rigidbody rigidbody;
	public float speed = 150;
	public int playerNumber = 1;
	public bool keyboard = false;

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
		float horizontal = 0.0f;
		float vertical = 0.0f;

		if (!keyboard){
			horizontal = Input.GetAxis ("Horizontal" + playerNumber);
			vertical = Input.GetAxis ("Vertical" + playerNumber);		
		}else {
			horizontal = Input.GetAxis ("Horizontal");
			vertical = Input.GetAxis ("Vertical");
		}


		isMovingVertical = false;
		isMovingHorizontal = false;

		// 0.01 for a "dead" zone
		if (horizontal > 0.01 || horizontal < -0.01f ){
			// move right / left
			newVelocity.x = speed * Time.deltaTime * horizontal;
			isMovingHorizontal = true;
		}
		// 0.01 for "dead zone
		if (vertical > 0.01 || vertical < -0.01){
			// move up
			newVelocity.z = speed * Time.deltaTime * vertical;
			isMovingVertical = true;
		}

		if (isMovingVertical && isMovingHorizontal){
			newVelocity = new Vector3(newVelocity.x / sqrt2, newVelocity.y / sqrt2, newVelocity.z / sqrt2);
		}
			

		rigidbody.velocity = newVelocity;

		//Debug.Log ("Magnitude = " + rigidbody.velocity.magnitude);
	}

	void FixedUpdate(){
		
	}
}

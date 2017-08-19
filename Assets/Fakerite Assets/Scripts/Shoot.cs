using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public ParticleSystem shootParticle;
	private float shootingDelay = 200;
	private float actualShootingTime;
	public float shootingSpeed = 10f;

	// Use this for initialization
	void Start () {
		actualShootingTime = shootingSpeed;
		shootParticle.Pause ();
	}

	// Update is called once per frame
	void Update (){
		
	}
		
	void FixedUpdate () {
		if (Input.GetAxis("Triggers") < 0){
			if (shootingDelay <= actualShootingTime){
				shootParticle.Emit (1);	
				actualShootingTime = 0;
			}else {
				actualShootingTime += shootingSpeed;
			}

		}else {
			actualShootingTime = shootingDelay;
		}
	}
}

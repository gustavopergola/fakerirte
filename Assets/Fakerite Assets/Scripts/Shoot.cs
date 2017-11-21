using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public ParticleSystem shootParticle;
	public ParticleSystem muzzleFlash;
	private float shootingDelay = 200;
	private float actualShootingTime;
	public float shootingSpeed = 10f;

	public AudioSource shootAudioSource;
	public AudioClip shootAudioClip;

	// Use this for initialization
	void Start () {
		actualShootingTime = shootingSpeed;
		shootParticle.Pause ();
	}

	// Update is called once per frame
	void Update (){
		
	}
		
	void FixedUpdate () {
		if (Input.GetAxis("Triggers") < 0 || Input.GetMouseButton(0)){
			if (shootingDelay <= actualShootingTime){
				shootParticle.Emit (1);	
				muzzleFlash.Emit (1);
				actualShootingTime = 0;
				shootAudioSource.PlayOneShot (shootAudioClip);
			}else {
				actualShootingTime += shootingSpeed;
			}

		}else {
			actualShootingTime = shootingDelay;
		}
	}
}

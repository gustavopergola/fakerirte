using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

	public GameObject shieldGO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Triggers") > 0) {
			shieldGO.SetActive (true);
		}else{
			shieldGO.SetActive (false);
		}
	}
}

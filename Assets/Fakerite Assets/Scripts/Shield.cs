using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject shieldGO;
	private bool activated;
	// Use this for initialization
	void Start () {
		activated = false;
	}

	void FixedUpdate () {
		if (Input.GetMouseButton(1)) {
			if (!activated){
				shieldGO.SetActive (true);
				activated = true;
			}
		}else if (activated){
			activated = false;
			shieldGO.SetActive (false);
		}
	}

	public bool isActivated(){
		return this.activated;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mouseRay : MonoBehaviour {

	public NavMeshAgent player;
	public Transform destination;

	// Use this for initialization
	void Start () {
		player.SetDestination (destination.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			ray.direction *= 1000;

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000f)){
				destination.position = new Vector3(hit.point.x, destination.position.y, hit.point.z);
				player.SetDestination (destination.position);
			}

		}
	}

}
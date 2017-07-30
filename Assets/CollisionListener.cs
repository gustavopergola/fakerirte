using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class CollisionListener : MonoBehaviour {

	public ParticleSystem part;
	public List<ParticleCollisionEvent> collisionEvents;

	// Use this for initialization
	void Start () {
		part = GetComponent<ParticleSystem> ();
		collisionEvents = new List<ParticleCollisionEvent> ();
	}
	
	// Update is called once per frame
	void OnParticleCollision(GameObject other)
	{
		int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

		int i = 0;

		while (i < numCollisionEvents)
		{
			if (collisionEvents[i].colliderComponent.gameObject.layer == 10){
				// player takes damage
				//Debug.Log ("Player took damage!");
			}

			i++;
		}
	}
		
}

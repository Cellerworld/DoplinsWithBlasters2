using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Collectable"))
		{
			other.enabled = false;
			Destroy(other.gameObject);
			GameEventManager.CollectedResource = Resource.MEAT;
			return;
		}
		if (other.CompareTag("Wood") && other.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
		{
			other.enabled = false;
			Destroy(other.gameObject);
			GameEventManager.CollectedResource = Resource.WOOD;
			return;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collting : MonoBehaviour {

	[SerializeField]
	private Inventory _playerInventory;

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
		if(other.CompareTag("Gold"))
		{
			other.enabled = false;
			Destroy(other.gameObject);
			GameEventManager.CollectedResource = Resource.COIN;
			return;
		}
		if (other.CompareTag("Wood") ) // && other.GetComponent<Rigidbody>().velocity.magnitude < 1f
		{
			other.enabled = false;
			Destroy(other.gameObject);
			GameEventManager.CollectedResource = Resource.WOOD;
			return;
		}
		if (other.CompareTag ("Treasure") && _playerInventory.Treasure < 1)
		{
			other.enabled = false;
			Destroy (other.gameObject);
			GameEventManager.CollectedResource = Resource.TREASURE;
			return;
		}
	}
}

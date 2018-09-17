using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cage : MonoBehaviour {

	[SerializeField, Range(4,12)]
	private int life = 5;

	private bool _alreadyAttacked;

	private ParticleSystem _Spills;
	[SerializeField]
	private GameObject woodDrop;

	void Start()
	{
		_Spills = GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(!_alreadyAttacked && other.tag == "Player")
		{
			_alreadyAttacked = true;
			life--;
			_Spills.Play ();
			if (life == 0)
			{
				for (int i = 0; i < 10; i++) {
					Instantiate (woodDrop, transform.position + new Vector3 (Random.Range (1, 3), Random.Range (1, 3), Random.Range (1, 3)), Quaternion.identity);
				}
				Destroy (this);
			}
		}
	}

	void OnTriggerExit()
	{
		_alreadyAttacked = false;
	}

}

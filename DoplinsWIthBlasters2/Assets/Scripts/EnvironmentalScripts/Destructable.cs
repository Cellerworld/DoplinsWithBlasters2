﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

	public int minWood;
	public int maxWood;
	[SerializeField]
	private GameObject woodDrop;

	[SerializeField]
	private GameObject stem;

	//[SerializeField]
	private ParticleSystem _leaves;

	[SerializeField]
	private GameObject _destroy;

	private void Start()
	{
		_leaves = GetComponentInChildren<ParticleSystem> ();
	}

//	private void Update()
//	{
//		if (!_leaves.isPlaying && Random.Range(0,100) < 10)
//		{
//			_leaves.Play ();
//		}
//
//	}

	private void OnApplicationQuit()
	{
		woodDrop = null;
	}

	private void OnDestroy()
	{
		if (woodDrop != null) {
			int rnd = Random.Range (minWood, maxWood);
			float radius = Random.Range (3, 5);
			Instantiate (stem, transform.position, Quaternion.identity).transform.localScale = new Vector3 (radius, 2, radius);
			 
			Destroy(Instantiate (_destroy, transform.position + Vector3.up, Quaternion.identity), 1f);
			for (int i = 0; i < rnd; i++) {
				Instantiate (woodDrop, transform.position + new Vector3 (Random.Range (1, 3), Random.Range (1, 3), Random.Range (1, 3)), Quaternion.identity);
			}
		}
	}
}




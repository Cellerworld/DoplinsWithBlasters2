using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

	public int minWood;
	public int maxWood;
	public GameObject woodDrop;

	//[SerializeField]
	private ParticleSystem _leaves;

	private void Start()
	{
		_leaves = GetComponentInChildren<ParticleSystem> ();
	}

	private void Update()
	{
		if (!_leaves.isPlaying && Random.Range(0,100) < 10)
		{
			_leaves.Play ();
		}

	}

	private void OnDestroy()
	{
		int rnd = Random.Range(minWood, maxWood);
		for (int i = 0; i < rnd; i++)
		{
			Instantiate(woodDrop, transform.position, Quaternion.identity);
		}
	}
}

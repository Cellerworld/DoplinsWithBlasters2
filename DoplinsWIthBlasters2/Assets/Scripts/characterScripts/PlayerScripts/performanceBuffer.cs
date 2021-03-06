﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class performanceBuffer : MonoBehaviour {

	[SerializeField]
	private Player _player;

	void Update()
	{
		this.transform.position = _player.transform.position + transform.up*1.5f;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Destructable")
		{
			Debug.Log ("leaves");
			if (other.GetComponent<ParticleSystem> ().isStopped || !other.GetComponent<ParticleSystem> ().isPlaying) {
					other.GetComponent<ParticleSystem> ().Play ();
			}
		}
		if (other.tag == "EnemyWave")
		{
			if (other.GetComponent<EnemyAgent> ().enabled == false) {
				other.GetComponent<EnemyAgent> ().enabled = true;

			}
			//other.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Destructable")
		{
			if(other.GetComponent<ParticleSystem> ().isPlaying)
			{
				other.GetComponent<ParticleSystem> ().Stop();
			}
		}
		if (other.tag == "EnemyWave")
		{
			if (other.GetComponent<EnemyAgent> ().enabled) {
				other.GetComponent<EnemyAgent> ().enabled = false;
			}
			//other.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
}

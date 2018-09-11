using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSounds : MonoBehaviour {

	private AudioSource[] _audioSrcs;

	// Use this for initialization
	void Start () {
		_audioSrcs = this.GetComponents<AudioSource> ();
		_audioSrcs[0].Play ();
		_audioSrcs[1].Play ();
	}

	private void OnTriggerStay(Collider other)
	{
		Vector3 distance = this.transform.position - other.transform.position;


		_audioSrcs[0].volume = 1 - distance.magnitude/25 ;

		_audioSrcs [1].volume = 1 - _audioSrcs[0].volume;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

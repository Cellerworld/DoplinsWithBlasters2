using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public int minWood;
    public int maxWood;
    public GameObject woodDrop;
	[SerializeField]
	private GameObject _destructParticles;

	[SerializeField]
	private ParticleSystem _LeaveParticles;
	void Start()
	{
	}

	private void Update()
	{
		if (!_LeaveParticles.isPlaying && Random.Range(0, 100) < 20)
		{
			_LeaveParticles.Play();
		}
	}

    private void OnDestroy()
    {
        int rnd = Random.Range(minWood, maxWood);
        for (int i = 0; i < rnd; i++)
        {
			Instantiate(_destructParticles ,transform.position, Quaternion.identity);
            Instantiate(woodDrop, transform.position, Quaternion.identity);
        }
    }
}

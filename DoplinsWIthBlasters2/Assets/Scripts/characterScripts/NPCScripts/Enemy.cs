using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	[SerializeField]
    float _dropPercentageMeat;
	[SerializeField]
	float _dropPercentageGold;
	[SerializeField]
	GameObject _meat;
	[SerializeField]
	GameObject _gold;

	private void OnDestroy()
    {
        int rnd = Random.Range(0, 100);
		if (_dropPercentageMeat >= rnd) {
			Instantiate (_meat, new Vector3 (transform.position.x, -0.25f, transform.position.z), Quaternion.identity);
		} 
		else if (_dropPercentageGold >= rnd) 
		{
			Instantiate (_gold, new Vector3 (transform.position.x, -0.25f, transform.position.z), Quaternion.identity);
		}
    }
}

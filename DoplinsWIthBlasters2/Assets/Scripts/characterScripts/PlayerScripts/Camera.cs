using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public GameObject target;

	private Vector3 _posDistance;
	private float distanceScaler = 1;
	private bool _increase = false;

	private void OnEnable()
	{

		_posDistance = new Vector3(0,10,-8);
		GameEventManager.OnUpgradeVillage += CameraZoom;

	}

	private void OnDisable()
	{
		GameEventManager.OnUpgradeVillage -= CameraZoom;
	}

	void Update () {
		if (_increase)
		{
			distanceScaler *= 1.01f;
		}
		if(distanceScaler > 3)
		{
			_increase = false;
		}
		if (!_increase)
		{
			distanceScaler *= (distanceScaler < 1.01f) ? 1: 0.99f;
		}

		Vector3 pos = new Vector3(target.transform.position.x, 0, target.transform.position.z ) + _posDistance * distanceScaler;
		transform.position = pos;
	}

	private void CameraZoom(Resource pResource, int amount)
	{
		_increase = true;
	}
}

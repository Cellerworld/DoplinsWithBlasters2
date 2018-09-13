using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public GameObject target;

	private Vector3 _posDistance;
	private float distanceScaler = 1;

	[SerializeField, Range(0.01f, 0.1f)]
	private float _zoomSpeed;

	private void OnEnable()
	{

		_posDistance = new Vector3(0,10,-8);
		GameEventManager.OnUpgradeVillage += CameraZoom;

	}

	private void OnDisable()
	{
		GameEventManager.OnUpgradeVillage -= CameraZoom;
	}
		

	void Update()
	{
		Vector3 pos = new Vector3(target.transform.position.x, 0, target.transform.position.z ) + _posDistance * distanceScaler;
		transform.position = pos;
	}

	private void CameraZoom(Resource pResource, int amount)
	{
		StartCoroutine (Zoom(_zoomSpeed));
	}

	IEnumerator Zoom(float speed)
	{
		while(distanceScaler < 3)
		{
			distanceScaler *= 1+ speed;
			yield return null;
		}
		GameEventManager.buildSettlement = true;
		yield return new WaitForSeconds(2);

		while(distanceScaler > 1)
		{
			distanceScaler *= 1 - speed;
			yield return null;
		}
	}
}

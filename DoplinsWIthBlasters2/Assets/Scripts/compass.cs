using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour {

	[SerializeField]
	private GameObject _player;

	private GameObject _granny;
	// Use this for initialization
	void Start () {
		_player = FindObjectOfType<Player> ().gameObject;
		_granny =  FindObjectOfType<Granny> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 _player2d = new Vector2(_player.transform.position.x, _player.transform.position.z);
		Vector2 _granny2d = new Vector2(_granny.transform.position.x, _granny.transform.position.z);

		Vector2 a =  new Vector2 (_player2d.x, _player2d.y+1) - _player2d;
		Vector2 b = _granny2d - _player2d;



		float Rotation = Mathf.Rad2Deg * Mathf.Atan2 (b.y, b.x) - 90f;

		Debug.Log (transform.localEulerAngles.z + "          " + Rotation);

		if(this.transform.localEulerAngles.z != Rotation)
		{
			Rotation -= this.transform.localEulerAngles.z;
			transform.Rotate (0, 0, Rotation);
		}
	}
}

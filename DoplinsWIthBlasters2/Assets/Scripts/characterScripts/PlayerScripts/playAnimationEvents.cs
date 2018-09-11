using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationEvents : MonoBehaviour {

//	[SerializeField]
//	private ParticleSystem _changeSlash;
//	[SerializeField]
//	private Animator _changeSlashBoxes;
//
//
//	[SerializeField]
//	private ParticleSystem _slash2;
//	[SerializeField]
//	private Animator _slash2Boxes;
//
//	[SerializeField]
//	private ParticleSystem _slashDown;
//	[SerializeField]
//	private Animator _slashDownBoxes;

	private AudioSource _audioSrc;

	[SerializeField]
	private GameObject _trail;

	[SerializeField]
	private ParticleSystem _slashImpact;
	private bool _isTrailing = false;

	[SerializeField]
	private AudioClip _slash1Sound;
	[SerializeField]
	private AudioClip _slash2Sound;
	[SerializeField]
	private AudioClip _slash3Sound;
	[SerializeField]
	private AudioClip _slash4Sound;

	private bool[] playedSound = new bool[4]{false, false , false , false};

	[SerializeField]
	private ParticleSystem _moveImpact;
	[SerializeField]
	private AudioClip _moveSound;

	private Player _player;
	private float _movementspeed;

	private void Start()
	{
		_audioSrc = GetComponent<AudioSource> ();
		_player = GetComponentInParent<Player> ();
		_movementspeed = _player.Speed;
	}

//	private void changeSlash()
//	{
//		_changeSlash.Play ();
//		_changeSlashBoxes.Play ("New Animation");
//	}
//
//	private void Slash2()
//	{
//		_slash2.Play ();
//		_slash2Boxes.Play ("New Animation");
//	}
//
//	private void Slashdown()
//	{
//		_slashDown.Play ();
//		_slash2Boxes.Play("Downwards");
//	}

	private void Trail()
	{
		_isTrailing = !_isTrailing;
		_trail.SetActive (_isTrailing);
	}

	private void SlashImpact()
	{
		_slashImpact.Play ();
	}

	private void MoveImpact()
	{
		_moveImpact.Play ();
	}

	private void EndMove()
	{
		_player.Speed = 0;
	}

	private void BeginMove()
	{
		_player.Speed = _movementspeed;
		if (!_audioSrc.isPlaying) {
			_audioSrc.PlayOneShot (_moveSound);
		}
	}

	private void Slash1Sound()
	{
		playedSound[0] = false;
		playedSound[1] = false;
		playedSound[2] = false;
		playedSound[3] = false;
		if (!playedSound [0]) {
			_audioSrc.PlayOneShot (_slash1Sound);
		}
		playedSound[0] = true;
	}

	private void Slash2Sound()
	{
		if (!playedSound [1]) {
		_audioSrc.PlayOneShot(_slash2Sound);
		}
		playedSound[1] = true;
	}

	private void Slash3Sound()
	{
		if (!playedSound [2]) {
		_audioSrc.PlayOneShot(_slash3Sound);
		}
		playedSound[2] = true;
	}

	private void Slash4Sound()
	{
		if (!playedSound [3]) {
		_audioSrc.PlayOneShot(_slash4Sound);
		}
		playedSound[3] = true;
	}
}

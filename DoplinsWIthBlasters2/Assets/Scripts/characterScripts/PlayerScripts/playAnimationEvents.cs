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

	[SerializeField]
	private Animator chest;

	private AudioSource[] _audioSrc;

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
	[SerializeField]
	private AudioClip _slash5Sound;

	[SerializeField]
	private AudioClip[] _slashVoices;

	private bool[] playedSound = new bool[5]{false, false , false , false, false};

	[SerializeField]
	private ParticleSystem _moveImpact;
	[SerializeField]
	private AudioClip[] _moveSound;

	private Player _player;
	private float _movementspeed;

	private void Start()
	{
		_audioSrc = GetComponents<AudioSource> ();
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

	private void TrailOff()
	{
		_isTrailing = false;
		_trail.SetActive (false);
	}

	private void SlashImpact()
	{
		_slashImpact.Play ();
		this.GetComponentInChildren<BoxCollider> ().size.Scale( new Vector3(50, 1, 2.5f));
		StartCoroutine (shrink ());
	}

	private IEnumerator shrink()
	{
		yield return new WaitForSeconds (35f);
		this.GetComponentInChildren<BoxCollider> ().size.Scale( new Vector3(0.02f, 1, 0.4f));

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
		if (!_audioSrc[0].isPlaying) {
			_audioSrc[0].PlayOneShot (_moveSound[Random.Range(0,3)]);
		}
	}

	private void Slash1Sound()
	{
		playedSound[0] = false;
		playedSound[1] = false;
		playedSound[2] = false;
		playedSound[3] = false;
		playedSound[4] = false;
		if (!playedSound [0]) {
			_audioSrc[1].PlayOneShot (_slash1Sound);
			_audioSrc [2].PlayOneShot (_slashVoices[Random.Range(0,6)]);
		}
		playedSound[0] = true;
	}

	private void Slash2Sound()
	{
		if (!playedSound [1]) {
			_audioSrc[1].PlayOneShot(_slash2Sound);
			if (Random.Range (0, 100) < 10 && !_audioSrc[2].isPlaying) {
				_audioSrc [2].PlayOneShot (_slashVoices [Random.Range (0, 6)]);
			}
		}
		playedSound[1] = true;
	}

	private void Slash3Sound()
	{
		if (!playedSound [2]) {
			_audioSrc[1].PlayOneShot(_slash3Sound);
			if (Random.Range (0, 100) < 10 && !_audioSrc[2].isPlaying) {
				_audioSrc [2].PlayOneShot (_slashVoices [Random.Range (0, 6)]);
			}
		}
		playedSound[2] = true;
	}

	private void Slash4Sound()
	{
		if (!playedSound [3]) {
			_audioSrc[1].PlayOneShot(_slash4Sound);
			if (Random.Range (0, 100) < 10 && !_audioSrc[2].isPlaying) {
				_audioSrc [2].PlayOneShot (_slashVoices [Random.Range (0, 6)]);
			}
		}
		playedSound[3] = true;
	}

	private void Slash5Sound()
	{
		if (!playedSound [4]) {
			_audioSrc[1].PlayOneShot(_slash4Sound);
			if (Random.Range (0, 100) < 10 && !_audioSrc[2].isPlaying) {
				_audioSrc [2].PlayOneShot (_slashVoices [Random.Range (0, 5)]);
			}
		}
		playedSound[4] = true;
	}

	private void slash1Begin()
	{
		chest.Play("Slash_1_Chest");
	}
	private void slash2Begin()
	{
		chest.Play("Slash_2_Chest");
	}
	private void slash3Begin()
	{
		chest.Play("Slash_3_Chest");
	}
	private void slash4Begin()
	{
		chest.Play("Slash_4_Chest");
	}

	private void moveBegin()
	{
		chest.Play("Walk_Chest");
	}
	private void dashBegin()
	{
		chest.Play("Dash_Chest");
	}
	private void idleBegin()
	{
		chest.Play ("Idle_Chest");
	}
}

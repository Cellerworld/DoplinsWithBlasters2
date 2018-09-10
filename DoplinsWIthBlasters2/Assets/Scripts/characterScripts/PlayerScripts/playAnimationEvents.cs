using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationEvents : MonoBehaviour {

	[SerializeField]
	private ParticleSystem _changeSlash;
	[SerializeField]
	private Animator _changeSlashBoxes;


	[SerializeField]
	private ParticleSystem _slash2;
	[SerializeField]
	private Animator _slash2Boxes;

	[SerializeField]
	private ParticleSystem _slashDown;
	[SerializeField]
	private Animator _slashDownBoxes;

	[SerializeField]
	private ParticleSystem _slashImpact;

	[SerializeField]
	private ParticleSystem _moveImpact;

	private void changeSlash()
	{
		_changeSlash.Play ();
		_changeSlashBoxes.Play ("New Animation");
	}

	private void Slash2()
	{
		_slash2.Play ();
		_slash2Boxes.Play ("New Animation");
	}

	private void Slashdown()
	{
		_slashDown.Play ();
		_slash2Boxes.Play("Downwards");
	}

	private void SlashImpact()
	{
		_slashImpact.Play ();
	}

	private void MoveImpact()
	{
		_moveImpact.Play ();
	}
}

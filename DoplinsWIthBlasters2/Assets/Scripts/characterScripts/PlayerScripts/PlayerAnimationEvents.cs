using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	[SerializeField]
	private ParticleSystem walkParticle;

	[SerializeField]
	private ParticleSystem hit4Particle;
	[SerializeField]
	private Animator _hit4Animator;

	[SerializeField]
	private ParticleSystem hit4BeginParticle;
	[SerializeField]
	private Animator _hit4BeginAnimator;

	[SerializeField]
	private ParticleSystem hit4EndParticle;

	[SerializeField]
	private ParticleSystem hit3Particle;
	[SerializeField]
	private Animator _hit3Animator;

	//Animation events
	private void JumpHitGround()
	{
		walkParticle.Play ();
	}


	private void Combo4Begin()
	{
		hit4BeginParticle.Play ();
		_hit4BeginAnimator.Play ("New Animation");
	}

	private void Combo4()
	{
		hit4Particle.Play ();
		_hit4Animator.Play ("Downwards");
	}

	private void Combo4End()
	{
		hit4EndParticle.Play ();
	}

	private void Combo3()
	{
		hit3Particle.Play ();
		_hit3Animator.Play ("New Animation");
	}
}

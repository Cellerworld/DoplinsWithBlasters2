using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
	[SerializeField]
	private  float _speed = 20f;

	[SerializeField]
	private  int _dashSpeedMultiplier = 10;

	[SerializeField]
	private float dashTime = 0.25f;

	[SerializeField]
	private float dashFallOff = 0.5f;

	private bool _dashing = false;
	private bool _dashResting = false;


	public float Speed
	{
		get
		{
			return _speed;
		}
		set
		{
			_speed = value;
		}
	}
    private Rigidbody rb;

	private Animator _animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
		_animator = this.GetComponentInChildren<Animator> ();
    }

    void Update () {
        Vector3 vel = new Vector3();
		if (Input.GetKey(KeyCode.W) && !_dashing)
        {
			
			_animator.SetTrigger ("move");
            vel.z = 1;
        }
		if (Input.GetKey(KeyCode.S) && !_dashing)
        {
			_animator.SetTrigger ("move");
            vel.z = -1;
        }
		if (Input.GetKey(KeyCode.A) && !_dashing)
        {
			_animator.SetTrigger ("move");
            vel.x = -1;
        }
		if (Input.GetKey(KeyCode.D) && !_dashing)
        {
			_animator.SetTrigger ("move");
            vel.x = 1;
        }
        
		if (Input.GetKey (KeyCode.LeftShift) && !_dashResting)
		{
			_dashResting = true;
			_dashing = true;
			_animator.Play ("Dash");
			StartCoroutine (Dash(vel.x, vel.z));
			vel = Vector3.zero;
		}



        if (vel.x != 0 || vel.z != 0)
        {
			ApplyMove (vel, 1);

//            vel.Normalize();
//            rb.velocity = vel * _speed * Time.deltaTime;
//            transform.rotation = Quaternion.LookRotation(vel);
        }
		else if(!_dashing)
        {
            rb.velocity = Vector3.zero;
        }
    }

	private IEnumerator Dash(float x, float z)
	{
		float Mulitplier = Mathf.Max(Mathf.Abs(x), Mathf.Abs(z))* _dashSpeedMultiplier;
		while (Mulitplier > 1) 
		{
			Mulitplier *= dashFallOff;


			ApplyMove (new Vector3(x, 0, z), Mulitplier);
			yield return new WaitForSeconds (dashTime/_dashSpeedMultiplier);
		}
		_dashing = false;
		yield return new WaitForSeconds (1f);


		_dashResting = false;
	}

	private void ApplyMove(Vector3 pVel, float multiplier)
	{
		pVel.Normalize();
		rb.velocity = pVel * _speed * multiplier * Time.deltaTime;
		transform.rotation = Quaternion.LookRotation(pVel);
	}
}

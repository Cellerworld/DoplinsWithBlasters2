using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
	[SerializeField]
	private  float _speed = 20f;
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
        if (Input.GetKey(KeyCode.W))
        {
			_animator.SetTrigger ("move");
            vel.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
			_animator.SetTrigger ("move");
            vel.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
			_animator.SetTrigger ("move");
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
			_animator.SetTrigger ("move");
            vel.x = 1;
        }
        
        if (vel.x != 0 || vel.z != 0)
        {
            vel.Normalize();
            rb.velocity = vel * _speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(vel);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}

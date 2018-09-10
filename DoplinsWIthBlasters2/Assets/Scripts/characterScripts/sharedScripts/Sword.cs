using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public bool isAttacking = false;

	[SerializeField]
	private ParticleSystem _treeBurst;

    private void OnTriggerEnter(Collider other)
    {
        if(isAttacking && other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        if(isAttacking && other.tag == "Destructable")
        {
			ParticleSystem a = Instantiate (_treeBurst);
			a.transform.position = other.transform.position;

            Destroy(other.gameObject);

			a.Play ();
			Destroy (a, 2);
        }
    }
}

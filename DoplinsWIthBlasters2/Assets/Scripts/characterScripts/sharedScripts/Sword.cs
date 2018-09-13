using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public bool isAttacking = false;



    private void OnTriggerEnter(Collider other)
    {
        if(isAttacking && other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
		if(isAttacking && other.tag == "Destructable" && other.tag == "Destructable2")
        {
            Destroy(other.gameObject);
        }
    }
}

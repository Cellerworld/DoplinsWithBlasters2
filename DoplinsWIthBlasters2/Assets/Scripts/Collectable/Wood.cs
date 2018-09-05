using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

    public float strength;
    Rigidbody rb;

    private void OnEnable()
    {
        Vector3 dir = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));
        dir.Normalize();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * strength);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float dropPercentage;
    public GameObject drop;

    private void OnDestroy()
    {
        int rnd = Random.Range(0, 100);
        if(dropPercentage >= rnd)
        {
            Instantiate(drop, new Vector3(transform.position.x, -0.25f, transform.position.z), Quaternion.identity);
        }
    }
}

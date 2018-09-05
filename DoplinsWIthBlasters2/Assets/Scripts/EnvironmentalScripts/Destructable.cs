using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public int minWood;
    public int maxWood;
    public GameObject woodDrop;

    private void OnDestroy()
    {
        int rnd = Random.Range(minWood, maxWood);
        for (int i = 0; i < rnd; i++)
        {
            Instantiate(woodDrop, transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject target;
	
	void Update () {
        Vector3 pos = new Vector3(target.transform.position.x, 7, target.transform.position.z - 2);
        transform.position = pos;
	}
}

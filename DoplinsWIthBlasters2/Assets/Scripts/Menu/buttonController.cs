using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour {

    private float increaseSize = 1.5f;

	public void IncreaseOnHover(GameObject other)
    {
        other.gameObject.transform.localScale *= increaseSize;

    }

    public void DecreaseOnHoverOff(GameObject other)
    {
        other.gameObject.transform.localScale *= 1/increaseSize;

    }
}

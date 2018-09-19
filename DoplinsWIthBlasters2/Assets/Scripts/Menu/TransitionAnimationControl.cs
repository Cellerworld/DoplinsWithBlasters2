using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationControl : MonoBehaviour {

    private void StopTransition()
    {
        this.gameObject.SetActive(false);
    }
}

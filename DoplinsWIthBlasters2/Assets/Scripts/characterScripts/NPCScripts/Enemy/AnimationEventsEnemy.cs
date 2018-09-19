using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventsEnemy : MonoBehaviour {

	private void setAttack()
	{

		MeshCollider[] swords = this.GetComponentsInChildren<MeshCollider> ();
		foreach(MeshCollider sword in swords)
		{
			sword.enabled = !sword.enabled;

		}


	}
		
}

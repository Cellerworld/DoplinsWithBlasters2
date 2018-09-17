using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

    public float strength;
    Rigidbody rb;

	private GameObject _player;

    private void OnEnable()
    {
		if (_player == null)
		{
			_player = FindObjectOfType<Player> ().gameObject;
		}

        Vector3 dir = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));
        dir.Normalize();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * strength);

		StartCoroutine (flyToPlayer());
    }

	private IEnumerator flyToPlayer()
	{
		yield return new WaitForSeconds (0.5f);
		this.GetComponent<Collider> ().isTrigger = true;
		while (this != null)
		{
			rb.velocity = new Vector3 ();
			Vector3 dir = _player.transform.position - this.transform.position;
			dir.Normalize ();
			rb.AddForce (dir * strength*5);
			yield return null;
		}
	}
}

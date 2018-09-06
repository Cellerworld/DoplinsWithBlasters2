using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Granny : MonoBehaviour {

	[SerializeField]
	private int[] goldNeeded = new int[8];
	[SerializeField]
	private int[] woodNeeded = new int[8];
	private int _upgradeLevel = 0;
	public GameObject textbox;
	private bool playerIsNearby;
	public Player player;
	public GameObject[] upgrade = new GameObject[8];
	[SerializeField]
	private Inventory _playerinventory;

	Text text;

	void Start()
	{
		text = textbox.GetComponentInChildren<Text> ();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerIsNearby && _playerinventory.CoinAmount >= goldNeeded[_upgradeLevel])
		{
			GameEventManager.UpgradeCost = goldNeeded[_upgradeLevel];
			//player.RemoveGold(goldNeeded);
			UpgradeTown();
		}
	}

	private void UpgradeTown()
	{
		upgrade[_upgradeLevel].SetActive(true);
		text.text = "Come back with " + goldNeeded[_upgradeLevel] + " gold.";
		_upgradeLevel++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			text.text = "Come back with " + goldNeeded[_upgradeLevel] + " gold.";
			Vector3 pos = transform.position;
			pos.y =2;
			textbox.transform.position = pos;
			textbox.SetActive(true);
			playerIsNearby = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsNearby = false;
			textbox.SetActive(false);
		}
	}
}

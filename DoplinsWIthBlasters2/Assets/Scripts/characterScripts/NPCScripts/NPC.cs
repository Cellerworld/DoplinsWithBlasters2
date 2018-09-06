﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public int stuffNeeded;
    public int goldReward;
    public float range;
    public GameObject textbox;
    private bool playerIsNearby = false;
    public Player player;
	[SerializeField]
	private Inventory _playerInventory;
	[SerializeField]
	private Resource _requiredResource;

	private delegate void getResourceRequired ();
	private getResourceRequired checkForRequiredResource;

	private void Start()
	{
		if(_requiredResource == Resource.MEAT)
		{
			checkForRequiredResource += Meat;
		}
		else if(_requiredResource == Resource.COIN)
		{
			checkForRequiredResource += Coin;
		}
		else if(_requiredResource == Resource.TREASURE)
		{
			checkForRequiredResource += Treasure;
		}
		else if(_requiredResource == Resource.WOOD)
		{
			checkForRequiredResource += Wood;
		}
	}

    private void Update()
    {
		if(Input.GetKeyDown(KeyCode.E) && playerIsNearby)
        {
			if (checkForRequiredResource != null) {
				checkForRequiredResource ();
			}
           // player.MakeExchange(stuffNeeded, goldReward);
        }
    }

	private void Coin()
	{
		if (_playerInventory.CoinAmount >= stuffNeeded)
		{
			GameEventManager.ExchangeForCurrency (Resource.COIN, -stuffNeeded, Resource.COIN, goldReward);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Wood()
	{
		if (_playerInventory.WoodAmount >= stuffNeeded)
		{
			GameEventManager.ExchangeForCurrency (Resource.WOOD, -stuffNeeded, Resource.COIN, goldReward);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Meat()
	{
		if (_playerInventory.MeatAmount >= stuffNeeded)
		{

			GameEventManager.ExchangeForCurrency (Resource.MEAT, -stuffNeeded, Resource.COIN, goldReward);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Treasure()
	{
		if (_playerInventory.Treasure >= stuffNeeded)
		{
			GameEventManager.ExchangeForCurrency (Resource.TREASURE, -stuffNeeded, Resource.COIN, goldReward);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 pos = transform.position;
            pos.y = 2;
            textbox.transform.position = pos;
            Text text = textbox.GetComponentInChildren<Text>();
            text.text = "Give me " + stuffNeeded + " stuff.";
            textbox.SetActive(true);
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsNearby = false;
            textbox.SetActive(false);
        }
    }
}

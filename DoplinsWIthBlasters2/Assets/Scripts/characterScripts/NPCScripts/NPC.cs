using System.Collections;
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

	//only needed for socializer quests
	[SerializeField]
	private GameObject _questTarget;
	[SerializeField]
	private ParticleSystem _happyExplosion;

	private delegate void getResourceRequired ();
	private getResourceRequired checkForRequiredResource;

	private string[] _resourceText;

	private void Start()
	{
		_resourceText = new string[2];
		if(_requiredResource == Resource.MEAT)
		{
			checkForRequiredResource += Meat;
			_resourceText[0] = "Get me ";
			_resourceText[1] = " meat Scrub";
		}
		//substitude for socializer house rescue quest
		else if(_requiredResource == Resource.COIN)
		{
			_resourceText[0] = "Help me save my ";
			_resourceText[1] = " house please";
			stuffNeeded = 1;
			checkForRequiredResource += Coin;
		}
		else if(_requiredResource == Resource.TREASURE)
		{
			checkForRequiredResource += Treasure;
			_resourceText[0] = "Find me ";
			_resourceText[1] = " treasure pal";
		}
		else if(_requiredResource == Resource.WOOD)
		{
			_resourceText[0] = "Save my ";
			_resourceText[1] = " life please";
			stuffNeeded = 1;
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
		if(Input.GetKeyDown(KeyCode.L) && playerIsNearby)
		{
			GameEventManager.ExchangeForCurrency (Resource.COIN, -0, Resource.COIN, 6000);
		}
	}

	private void Coin()
	{
		if (!_questTarget.activeSelf)
		{
			_resourceText[0] = "Thank you ";
			_resourceText[1] = " ";
			GameEventManager.ExchangeForCurrency (Resource.COIN, 0, Resource.COIN, goldReward);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Wood()
	{
		if (!_questTarget.activeSelf)
		{
			_resourceText[0] = "Thank you ";
			_resourceText[1] = " ";
			GameEventManager.ExchangeForCurrency (Resource.WOOD, 0, Resource.WOOD, goldReward);
			_happyExplosion.Play ();
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
			pos.y = 3;
			textbox.transform.position = pos;
			Text text = textbox.GetComponentInChildren<Text>();
			if (_requiredResource == Resource.MEAT || _requiredResource == Resource.TREASURE) {
				text.text = _resourceText [0] + stuffNeeded + _resourceText [1] + "      " + goldReward + " gold";
			}
			else
			{
				text.text = _resourceText [0] + _resourceText [1];
			}
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

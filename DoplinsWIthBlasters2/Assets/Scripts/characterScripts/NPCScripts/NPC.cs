using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

	public int stuffNeeded;
	public int[] goldReward;
	private int RewardLevel = 0;
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

	private bool _isFinished = true;

	private string[] _resourceText;

	Text[] text;

	[SerializeField]
	Image[] images = new Image[2];
	[SerializeField]
	Sprite[] sprites = new Sprite[2];

	private void Start()
	{
		text = textbox.GetComponentsInChildren<Text> ();


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
		if(Input.GetKeyDown(KeyCode.E) && playerIsNearby && _isFinished)
		{
			if (checkForRequiredResource != null) {
				checkForRequiredResource ();
			}
			// player.MakeExchange(stuffNeeded, goldReward);
		}
		if(Input.GetKeyDown(KeyCode.L) && playerIsNearby)
		{
			GameEventManager.ExchangeForCurrency (Resource.WOOD, 6000, Resource.COIN, 6000);
		}
		if ((_requiredResource == Resource.WOOD || _requiredResource == Resource.COIN) && _questTarget == null && playerIsNearby)
		{
			_resourceText[0] = "Thanks. ";
			_resourceText[1] = " Please help my Brothers aswell.";
			text[0].text = _resourceText [0] + _resourceText [1];
		}
	}

	private void Coin()
	{
		if (_questTarget == null)
		{
			_isFinished = false;
			GameEventManager.helpedSocializer = true;
			GameEventManager.ExchangeForCurrency (Resource.COIN, 0, Resource.COIN, goldReward[0]);
			Instantiate (_happyExplosion, transform.position + new Vector3(0,1,0), Quaternion.identity).Play ();
			StartCoroutine ("explode");
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Wood()
	{
		if (_questTarget == null)
		{
			GameEventManager.helpedSocializer = true;
			_isFinished = false;
			GameEventManager.ExchangeForCurrency (Resource.WOOD, 0, Resource.COIN, goldReward[0]);
			Instantiate (_happyExplosion, transform.position + new Vector3(0,1,0), Quaternion.identity).Play ();
			StartCoroutine ("explode");
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Meat()
	{
		if (_playerInventory.MeatAmount >= stuffNeeded)
		{

			GameEventManager.ExchangeForCurrency (Resource.MEAT, -stuffNeeded, Resource.COIN, goldReward[0]);
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void Treasure()
	{
		if (_playerInventory.Treasure >= stuffNeeded)
		{
			GameEventManager.ExchangeForCurrency (Resource.TREASURE, -stuffNeeded, Resource.COIN, goldReward[RewardLevel]);
			RewardLevel++;
			//player.MakeExchange(stuffNeeded, goldReward);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if (sprites [0] != null) {
				images [0].sprite = sprites [0];
				images [1].sprite = sprites [1];
			}

			Vector3 pos = transform.position;
			pos.y = 3;
			textbox.transform.position = pos;

			if (_requiredResource == Resource.MEAT || _requiredResource == Resource.TREASURE) {
				text[1].text = "NEEDED";
				text[0].text = "*" + stuffNeeded;
				text[2].text = "REWARD";
				text[3].text = "*" + goldReward[RewardLevel];
				text[4].text = "TRADE";
			}
			else
			{
				text[0].text = _resourceText [0] + _resourceText [1];
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

	private IEnumerator explode()
	{
		while(this.gameObject.transform.localScale.x > 0.05f)
		{
			this.gameObject.transform.position += new Vector3 (0, 0.05f, 0);
			this.gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
			yield return new WaitForSeconds(0.10f);
		}
		yield return new WaitForSeconds (3.5f);
		Destroy (this);
	}
}

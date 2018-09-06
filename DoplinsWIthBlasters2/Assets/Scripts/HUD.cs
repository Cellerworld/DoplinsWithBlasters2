using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	private int _coinStock;
	private int _woodStock;
	private int _meatStock;
	private int _treasureStock;

	[SerializeField]
	private Text _coinText;

	[SerializeField]
	private Text _woodText;

	[SerializeField]
	private Text _meatText;

	[SerializeField]
	private Text _treasureText;

	private delegate void checkHudItems(Resource pResource, int pAmount);
	private checkHudItems _checkHudItems;


	// Use this for initialization
	void Start () {
		_coinStock = 0;
		_woodStock = 0;
		_meatStock = 0;
		_treasureStock = 0;

		_checkHudItems += updateCoin;
		_checkHudItems += updateMeat;
		_checkHudItems += updateTreasure;
		_checkHudItems += updateWood;
	}
	
	private void OnEnable()
	{
		GameEventManager.OnCollecting += changeHud;
		GameEventManager.OnGiveMaterial += changeHud2;
		GameEventManager.OnUpgradeVillage += changeHud;
	}
	private void OnDisable()
	{
		GameEventManager.OnCollecting -= changeHud;
		GameEventManager.OnGiveMaterial -= changeHud2;
		GameEventManager.OnUpgradeVillage -= changeHud;
	}

	private void changeHud(Resource pResource, int pAmount)
	{
		_checkHudItems (pResource, pAmount);
	}

	private void changeHud2(Resource pResourceGiven, int pAmountGiven, Resource pResourceTaken, int pAmountTaken)
	{
		_checkHudItems (pResourceGiven, pAmountGiven);
		_checkHudItems (pResourceTaken, pAmountTaken);
	}

	private void updateCoin(Resource pResource, int pAmount)
	{
		if(pResource == Resource.COIN)
		{
			_coinStock += pAmount;
			_coinText.text = "Coins: " + _coinStock;
		}
	}

	private void updateWood(Resource pResource, int pAmount)
	{
		if(pResource == Resource.WOOD)
		{
			_woodStock += pAmount;
			_woodText.text = "Wood: " + _woodStock;
		}
	}

	private void updateMeat(Resource pResource, int pAmount)
	{
		if(pResource == Resource.MEAT)
		{
			_meatStock += pAmount;
			_meatText.text = "Meat: " + _meatStock;
		}
	}

	private void updateTreasure(Resource pResource, int pAmount)
	{
		if(pResource == Resource.TREASURE)
		{
			_treasureStock += pAmount;

			_treasureText.text = "Treasure: " + _treasureStock;
		}
	}
}


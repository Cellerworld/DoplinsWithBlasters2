using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUD : MonoBehaviour {

	private int _coinStock;
	private int _woodStock;
	private int _meatStock;
	private int _treasureStock;

	[SerializeField]
	private TextMeshProUGUI _coinText;

	[SerializeField]
	private TextMeshProUGUI _woodText;

	[SerializeField]
	private TextMeshProUGUI _meatText;

//	[SerializeField]
//	private TextMeshPro _treasureText;

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
		//_checkHudItems += updateTreasure;
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
			_coinText.text =   _coinStock.ToString();
		}
	}

	private void updateWood(Resource pResource, int pAmount)
	{
		if(pResource == Resource.WOOD)
		{
			_woodStock += pAmount;
			_woodText.text =  _woodStock.ToString();
		}
	}

	private void updateMeat(Resource pResource, int pAmount)
	{
		if(pResource == Resource.MEAT)
		{
			_meatStock += pAmount;
			_meatText.text = _meatStock.ToString();
		}
	}

//	private void updateTreasure(Resource pResource, int pAmount)
//	{
//		if(pResource == Resource.TREASURE)
//		{
//			_treasureStock += pAmount;
//
//			_treasureText.text = "Treasure: " + _treasureStock;
//		}
//	}
}


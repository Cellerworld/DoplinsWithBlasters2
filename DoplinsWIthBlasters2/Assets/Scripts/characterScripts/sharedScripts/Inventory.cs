using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	private int _woodAmount;
	public int WoodAmount
	{
		get
		{
			return _woodAmount;
		}
	}

	private int _coinAmount;
	public int CoinAmount
	{
		get
		{
			return _coinAmount;
		}
	}

	private int _treasureAmount;
	public int Treasure
	{
		get
		{
			return _treasureAmount;
		}
	}

	private int _meatAmount;
	public int MeatAmount
	{
		get
		{
			return _meatAmount;
		}
	}

	private delegate void checkResource(Resource pResource, int pAmount);
	private checkResource _checkResource;


	// Use this for initialization
	void Start () {
		_woodAmount = 0;
		_coinAmount = 0;

		_checkResource += changeCoinStock;
		_checkResource += changeWoodStock;
		_checkResource += changeMeatStock;
		_checkResource += changeTreasureStock;
	}


	private void OnEnable()
	{
		GameEventManager.OnCollecting += changeStock;
		GameEventManager.OnGiveMaterial += Exchange ;
		GameEventManager.OnUpgradeVillage += changeStock;
	}

	private void OnDisable()
	{
		GameEventManager.OnCollecting -= changeStock;
		GameEventManager.OnGiveMaterial -= Exchange ;
		GameEventManager.OnUpgradeVillage -= changeStock;
	}

	private void changeStock( Resource pResource, int pAmount)
	{
		_checkResource(pResource, pAmount);
	}

	//first amount negative number, second amountpositive number
	private void Exchange(Resource pResourceGiven, int pAmountGiven, Resource pResourceTaken, int pAmountTaken)
	{
		_checkResource (pResourceGiven, pAmountGiven);
		_checkResource (pResourceTaken, pAmountTaken);
	}

	private void RemoveCoins(Resource pResource, int pAmount)
	{
		_coinAmount -= pAmount;
	}

	private void changeWoodStock( Resource pResource, int pAmount)
	{
		if(pResource == Resource.WOOD)
		{
			
			_woodAmount += pAmount;
		}
	}

	private void changeMeatStock(Resource pResource, int pAmount)
	{
		if(pResource == Resource.MEAT)
		{
			
			_meatAmount += pAmount;
		}
	}

	private void changeTreasureStock(Resource pResource, int pAmount)
	{
		if(pResource == Resource.TREASURE)
		{
			_treasureAmount += pAmount;
		}
	}

	private void changeCoinStock(Resource pResource, int pAmount)
	{
		if(pResource == Resource.COIN)
		{
			_coinAmount += pAmount;
		}
	}


}

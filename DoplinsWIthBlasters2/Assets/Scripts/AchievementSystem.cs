using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour {

	private delegate void improve(Resource pResource ,int pAmount);
	private improve _improve;

	private int gatheredWood = 0;
	private int _woodGoal = 3;

	private int gatheredCoins= 0;
	private int _coinGoal = 5;

	private int gatheredTreasures= 0;
	private int _treasureGoal = 1;

	private int gatheredKills= 0;
	private int _killGoal = 4;

	private Dictionary<Achievment, int> _achievmentLevel = new Dictionary<Achievment,int>();

	// Use this for initialization
	void Start () {
		_improve += AddCoin;
		_improve += AddKill;
		_improve += AddTreasure;
		_improve += AddWood;

		_achievmentLevel.Add (Achievment.WOODSMAN, 0);
		_achievmentLevel.Add (Achievment.BANKER, 0);
		_achievmentLevel.Add (Achievment.BUFFER, 0);
		_achievmentLevel.Add (Achievment.HEALER, 0);
		_achievmentLevel.Add (Achievment.HULK, 0);
		_achievmentLevel.Add (Achievment.KILLER, 0);
		_achievmentLevel.Add (Achievment.TREASUREHUNTER, 0);
	}

	private void OnEnable()
	{
		GameEventManager.OnCollecting += Collect;
	}

	private void OnDisable()
	{
		GameEventManager.OnCollecting -= Collect;
	}

	private void Collect(Resource pResource, int pAmount)
	{
		if (_improve != null)
		{
			_improve (pResource, pAmount);
		}
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddWood(Resource pResource , int pAmount)
	{
		if (pResource == Resource.WOOD)
		{
			gatheredWood += pAmount;
			if (gatheredWood => _woodGoal)
			{
				_woodGoal *= 2;
				//Set Trigger for Achievment up
				_achievmentLevel[Achievment.WOODSMAN]++;
				GameEventManager.upgradedAchievmentLevel = _achievmentLevel [Achievment.WOODSMAN];
				GameEventManager.upgradedAchievment = Achievment.WOODSMAN;
			}
		}

	}

	private void AddCoin(Resource pResource , int pAmount)
	{
		if (pResource == Resource.COIN)
		{
			gatheredCoins += pAmount;
			if (gatheredCoins => _coinGoal)
			{
				_coinGoal *= 2;
				//Set Trigger for Achievment up
				_achievmentLevel[Achievment.BANKER]++;
				GameEventManager.upgradedAchievmentLevel = _achievmentLevel [Achievment.BANKER];
				GameEventManager.upgradedAchievment = Achievment.BANKER;
			}
		}

	}

	private void AddTreasure ( Resource pResource ,int pAmount)
	{
		if (pResource == Resource.TREASURE)
		{
			gatheredTreasures += pAmount;
			if (gatheredTreasures => _treasureGoal)
			{
				_treasureGoal *= 2;
				//Set Trigger for Achievment up
				_achievmentLevel[Achievment.TREASUREHUNTER]++;
				GameEventManager.upgradedAchievmentLevel = _achievmentLevel [Achievment.TREASUREHUNTER];
				GameEventManager.upgradedAchievment = Achievment.TREASUREHUNTER;
			}
		}

	}

	private void AddKill(Resource pResource , int pAmount)
	{
		if (pResource == Resource.MEAT)
		{
			gatheredKills += pAmount;
			if (gatheredKills => _killGoal)
			{
				_killGoal *= 2;
				//Display Achievment
				//Set Trigger for Achievment up
				_achievmentLevel[Achievment.KILLER]++;
				GameEventManager.upgradedAchievmentLevel = _achievmentLevel [Achievment.KILLER];
				GameEventManager.upgradedAchievment = Achievment.KILLER;

			}
		}

	}

	public int getAchievementLevel(Achievment pAchievment)
	{
		return _achievmentLevel[pAchievment];
	}
}

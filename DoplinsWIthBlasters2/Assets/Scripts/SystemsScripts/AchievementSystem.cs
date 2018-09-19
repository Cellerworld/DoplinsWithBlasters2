using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour {

	private delegate void improve(Resource pResource ,int pAmount);
	private improve _improve;

	private int gatheredWood = 0;
	[SerializeField]
	private int[] _woodGoal = new int[5];
	private int _woodLevel = 0;

	private int gatheredCoins= 0;
	[SerializeField]
	private int[] _coinGoal  = new int[5];
	private int _coinLevel = 0;

	private int gatheredTreasures= 0;
	[SerializeField]
	private int[] _treasureGoal  = new int[5];
	private int _tresureLevel = 0;

	private int gatheredKills= 0;
	[SerializeField]
	private int[] _killGoal  = new int[4];
	private int _killLevel = 0;

	private int gatheredScoializers= 0;
	[SerializeField]
	private int[] _socializerGoal  = new int[4];
	private int _socialLevel = 0;

	private int gatheredAchievments= 0;
	[SerializeField]
	private int[] _achievmentGoals  = new int[3];
	private int _achieveLevel = 0;

	private bool _gotTen;

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
			if (gatheredWood >= _woodGoal[_achievmentLevel[Achievment.WOODSMAN]])
			{
				//_woodGoal *= 2;
				//Set Trigger for Achievment up
				gatheredAchievments++;
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
			if (gatheredCoins >= _coinGoal[_achievmentLevel[Achievment.BANKER]])
			{
				//_coinGoal *= 2;
				//Set Trigger for Achievment up
				gatheredAchievments++;
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
			if (gatheredTreasures >= _treasureGoal[_achievmentLevel[Achievment.TREASUREHUNTER]])
			{
				//_treasureGoal *= 2;
				//Set Trigger for Achievment up
				gatheredAchievments++;
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
			if (gatheredKills >= _killGoal[_achievmentLevel[Achievment.KILLER]])
			{
				//_killGoal *= 2;
				//Display Achievment
				//Set Trigger for Achievment up
				gatheredAchievments++;
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

	public int getMeat()
	{
		return gatheredKills;
	}

	public int getWood()
	{
		return gatheredWood;
	}
	public int getTreasure()
	{
		return gatheredTreasures;
	}

	public int getAchievments()
	{
		return gatheredAchievments;
	}
}

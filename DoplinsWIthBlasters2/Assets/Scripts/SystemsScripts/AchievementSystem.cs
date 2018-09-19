using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

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
	private int[] _treasureGoal  = new int[3];
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

	[SerializeField]
	private GameObject[] images;

	private Dictionary<Achievment, int> _achievmentLevel = new Dictionary<Achievment,int>();

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);

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
		_achievmentLevel.Add (Achievment.SOCIALIZER, 0);
	}

	private void OnEnable()
	{
		GameEventManager.OnCollecting += Collect;
		GameEventManager.OnSocializerHelp += AddSocializer;
	}

	private void OnDisable()
	{
		GameEventManager.OnCollecting -= Collect;
		GameEventManager.OnSocializerHelp -= AddSocializer;
	}

	private void Collect(Resource pResource, int pAmount)
	{
		if (_improve != null)
		{
			_improve (pResource, pAmount);
			AddSocializer ();
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
				StartCoroutine (ShowAchivement (images[3], "Woodsman ", Achievment.WOODSMAN ));
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
				//StartCoroutine (ShowAchivement (images[0]));
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
				StartCoroutine (ShowAchivement (images[2], "Treasurehunter ", Achievment.TREASUREHUNTER));
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
				StartCoroutine (ShowAchivement (images[1], "Killer ", Achievment.KILLER));
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

	private void AddSocializer()
	{
		
		gatheredScoializers ++;
		if (gatheredScoializers >= _socializerGoal[_achievmentLevel[Achievment.SOCIALIZER]])
			{
			StartCoroutine (ShowAchivement (images[0], "Justice Warrior ", Achievment.SOCIALIZER));
				//_killGoal *= 2;
				//Display Achievment
				//Set Trigger for Achievment up
				gatheredAchievments++;
			_achievmentLevel[Achievment.SOCIALIZER]++;
			GameEventManager.upgradedAchievmentLevel = _achievmentLevel [Achievment.SOCIALIZER];
			GameEventManager.upgradedAchievment = Achievment.SOCIALIZER;
			Debug.Log ("social guy");
			}


	}

	private IEnumerator ShowAchivement(GameObject pImage, String achievmentName, Achievment pAchievment)
	{
		Image rImage = pImage.GetComponent<Image> ();
		TextMeshProUGUI text = pImage.GetComponentInChildren<TextMeshProUGUI> ();
		text.text = achievmentName + "Level" + _achievmentLevel[pAchievment];
		text.alpha = 1;
		rImage.color += new Color (0, 0, 0, 1);
		pImage.transform.localScale = new Vector3 (0.01f, 0.01f, 0.01f);
		pImage.SetActive (true);
		while (pImage.transform.localScale.x < 1.7f)
		{
			pImage.transform.localScale *= 1.05f;
			yield return null;
		}

		while (rImage.color.a > 0.05f) 
		{
			rImage.color *= new Color (1, 1, 1, 0.99f);
			text.alpha = text.alpha * 0.99f;
			yield return null;
		}
		pImage.SetActive (false);

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

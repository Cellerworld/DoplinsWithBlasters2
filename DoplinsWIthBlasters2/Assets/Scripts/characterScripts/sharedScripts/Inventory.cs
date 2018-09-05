using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	private int _woodAmount;
	public int WoddAmount
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

	private int _treasure;
	public int Treasure
	{
		get
		{
			return _treasure;
		}
	}

	// Use this for initialization
	void Start () {
		_woodAmount = 0;
		_coinAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

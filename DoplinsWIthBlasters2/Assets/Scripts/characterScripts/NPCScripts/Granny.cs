using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Granny : MonoBehaviour {

	[SerializeField]
	private int[] goldNeeded = new int[8];
	[SerializeField]
	private int[] woodNeeded = new int[8];

	private int _upgradeLevel = 0;
	private float scaleOfBuilding = 0.01f;
	private Vector3 _originalScale;
	[SerializeField, Range(1f, 2f)]
	private float speedOfBuilding;

	public GameObject textbox;
	private bool playerIsNearby;
	public Player player;
	public GameObject[] upgrade = new GameObject[8];
	[SerializeField]
	private Inventory _playerinventory;

	[SerializeField]
	private GameObject _construction;

	Text text;

	void Start()
	{
		text = textbox.GetComponentInChildren<Text> ();
	}

	void OnEnable()
	{
		GameEventManager.OnBuildSettlement += StartBuilding;
	}

	void OnDisable()
	{
		GameEventManager.OnBuildSettlement -= StartBuilding;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerIsNearby && _playerinventory.CoinAmount >= goldNeeded[_upgradeLevel])
		{
			GameEventManager.UpgradeCost = goldNeeded[_upgradeLevel];
			//player.RemoveGold(goldNeeded);
			UpgradeTown();
		}
	}

	private void StartBuilding()
	{
		_originalScale = upgrade [_upgradeLevel].transform.localScale;
		StartCoroutine (Building ());
	}

	private void UpgradeTown()
	{
		
		text.text = "Come back with " + goldNeeded[_upgradeLevel+1] + " gold.";
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			text.text = "Come back with " + goldNeeded[_upgradeLevel] + " gold.";
			Vector3 pos = transform.position;
			pos.y =2;
			textbox.transform.position = pos;
			textbox.SetActive(true);
			playerIsNearby = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsNearby = false;
			textbox.SetActive(false);
		}
	}

	private IEnumerator Building()
	{
		upgrade [_upgradeLevel].transform.localScale = new Vector3 ( _originalScale.x, _originalScale.y*scaleOfBuilding, _originalScale.z);
		upgrade[_upgradeLevel].SetActive(true);
		while(scaleOfBuilding < 1)
		{
			scaleOfBuilding *= speedOfBuilding;
			Mathf.Clamp01 (scaleOfBuilding);
			_construction.transform.position = upgrade [_upgradeLevel].transform.position;
			upgrade [_upgradeLevel].transform.localScale = new Vector3 ( _originalScale.x, _originalScale.y*scaleOfBuilding, _originalScale.z);
			Instantiate (_construction);
			yield return null;
		}
		scaleOfBuilding = 0.01f;
		_upgradeLevel++;
	}
		
}

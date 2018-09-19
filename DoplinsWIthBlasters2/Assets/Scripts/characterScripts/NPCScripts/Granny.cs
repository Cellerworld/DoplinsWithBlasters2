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
	private GameObject[] CleanupUpgrade = new GameObject[3];

	private bool _is_ready = true;

	[SerializeField]
	private Inventory _playerinventory;

	[SerializeField]
	private GameObject _construction;

	Text[] text;

	[SerializeField]
	Image[] images = new Image[2];
	[SerializeField]
	Sprite[] sprites = new Sprite[2];

	void Start()
	{
		text = textbox.GetComponentsInChildren<Text> ();


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
		if (Input.GetKeyDown(KeyCode.E) && playerIsNearby && _playerinventory.CoinAmount >= goldNeeded[_upgradeLevel] && _playerinventory.WoodAmount >= woodNeeded[_upgradeLevel] && _is_ready)
		{
			_is_ready = false;
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

		text[1].text = "NEEDED";
		text[0].text = "*" + goldNeeded[_upgradeLevel+1].ToString();
		text[2].text = "NEEDED";
		text[3].text = "*" +woodNeeded[_upgradeLevel+1].ToString();
		text[4].text = "UPGRADE";
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			images [0].sprite = sprites [0];
			images [1].sprite = sprites [1];

			text[1].text = "NEEDED";
			text[0].text = "*" + goldNeeded[_upgradeLevel].ToString();
			text[2].text = "NEEDED";
			text[3].text = "*" + woodNeeded[_upgradeLevel].ToString();
			text[4].text = "UPGRADE";

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

		if (_upgradeLevel == 4) 
		{
			CleanupUpgrade [0].SetActive (false);
		}
		else if(_upgradeLevel == 6)
		{
			CleanupUpgrade [1].SetActive (false);
		}
		else if(_upgradeLevel == 7)
		{
			CleanupUpgrade [2].SetActive (false);
		}

		foreach (Transform trans in upgrade [_upgradeLevel].GetComponentsInChildren<Transform>()) 
		{
			Debug.Log (trans.tag);
			//Destroy (Instantiate (_construction, upgrade [_upgradeLevel].transform.position, upgrade [_upgradeLevel].transform.rotation), 1.5f);
			if (trans.tag == "MainBuilding") 
			{
				Debug.Log ("instantiate particle");
				Destroy (Instantiate (_construction, trans.position, trans.rotation), 2.9f);
			}
		}

		while(scaleOfBuilding < 1)
		{
			scaleOfBuilding *= speedOfBuilding;
			Mathf.Clamp01 (scaleOfBuilding);
			_construction.transform.position = upgrade [_upgradeLevel].transform.position;
			upgrade [_upgradeLevel].transform.localScale = new Vector3 ( _originalScale.x, _originalScale.y*scaleOfBuilding, _originalScale.z);



			yield return null;
		}
		scaleOfBuilding = 0.01f;
		_upgradeLevel++;
		yield return new WaitForSeconds (2);
		_is_ready = true;
	}

}

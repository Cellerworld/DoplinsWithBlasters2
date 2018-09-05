using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : MonoBehaviour {

	private int buildingLevel = 0;

	[SerializeField]
	private int maxBuildLevel =5;

	//serialize all prefabs for the buildings here
	[SerializeField]
	private GameObject[] buildings; 

	// Use this for initialization
	void Start () {
		
	}


	private void OnEnable()
	{
		GameEventManager.OnUpgradeVillage += Upgrade;
		GameEventManager.OnDestroyBuilding += Downgrade;
	}

	private void OnDisable()
	{
		GameEventManager.OnUpgradeVillage -= Upgrade;
		GameEventManager.OnDestroyBuilding -= Downgrade;
	}

	//Destroys old building and loads better one
	private void Upgrade(Resource pResource, int pAmount)
	{
		buildings[buildingLevel].SetActive(false);
		buildingLevel++;
		if (buildingLevel == maxBuildLevel )
		{
			//Eventtrigger Game won
		}
		buildings[buildingLevel].SetActive(true);
	}

	//Destroys old building and loads old one
	private void Downgrade()
	{
		buildings[buildingLevel].SetActive(false);
		buildingLevel--;
		if (buildingLevel < 0) {
			//Eventtrigger Gameover

		}
		else
		{
			buildings [buildingLevel].SetActive (true);
		}
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : MonoBehaviour {

	private int buildingLevel = 0;

	[SerializeField]
	private int maxBuildLevel =5;

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

	private void Upgrade()
	{
		buildings[buildingLevel].SetActive(false);
		buildingLevel++;
		if (buildingLevel == maxBuildLevel )
		{
			//Eventtrigger Game won
		}
		buildings[buildingLevel].SetActive(true);
	}

	private void Downgrade()
	{
		buildings[buildingLevel].SetActive(false);
		buildingLevel--;
		if (buildingLevel < 0)
		{
			//Eventtrigger Gameover

		}
		buildings[buildingLevel].SetActive(true);
	}
		
}

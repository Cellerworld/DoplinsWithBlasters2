using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public enum Resource {NONE, WOOD, COIN, POTION, MEGAPOTION, BERRY, MEAT, TREASURE};
public enum Achievment {NONE, WOODSMAN, BANKER, HULK, BUFFER, HEALER, KILLER, TREASUREHUNTER};

public class GameEventManager : MonoBehaviour {

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
    public static bool PlayerIsdead = false;

	//The attacker knows when he hid something and delivers his damage, the attacked knows he was attacked and sets a variable on for receiving damage
	//alternative just use the collisio bodies in the check to check on stats per get method
//	public delegate void Attack(int damage);
//  	public static event Attack OnAttack;

	//player, achievmentsystem and itemdrop are intrested in this.
    public delegate void EnemyDeath();
    public static event EnemyDeath OnEnemyDeath;

	//player and achievmentsystem are intrested in this.
	public delegate void Collect(Resource resource, int pAmount);
	public static event Collect OnCollecting;
	public static Resource CollectedResource;

	//hud and wavespawner are intrested in this
	public delegate void Wavespawn();
	public static event Wavespawn OnWavespawn;

	//upgrade NPC, the town and the player is intrested in this
	public delegate void UpgradeVillage(Resource pResource, int pAmount);
	public static event UpgradeVillage OnUpgradeVillage;
	public static int UpgradeCost;

	public delegate void DestroyBuilding();
	public static event DestroyBuilding OnDestroyBuilding;

	//Hud and trophy gallery is intrested in this
	public delegate void AchievmentUp(Achievment pAchievment, int pAchievmentLevel);
	public static event AchievmentUp OnAchievementUp;
	public static Achievment upgradedAchievment = Achievment.NONE;
	public static int upgradedAchievmentLevel;

	//player and interacted npc are intrested in this
	//first amount negative number, second amountpositive number
	public delegate void GiveMaterial(Resource pResourceGiven, int pAmountGiven, Resource pResourceTaken, int pAmountTaken);
	public static event GiveMaterial OnGiveMaterial;
	private static Resource _givenResource = Resource.NONE; 
	private static int _givenAmount; 
	private static Resource _takenResource; 
	private static int _takenAmount; 
	public static void ExchangeForCurrency(Resource pResourceGiven, int pAmountGiven, Resource pResourceTaken, int pAmountTaken)
	{
		_givenResource = pResourceGiven;
		_givenAmount = pAmountGiven;
		_takenResource = pResourceTaken;
		_takenAmount = pAmountTaken;
	}

	//neraly everyone is intrested in this
	public delegate void EndGame();
	public static event EndGame OnEndGame;


	//for faster coding.
	private delegate void CheckEvents();
    private CheckEvents _eventCheck;



    // Use this for initialization
    void Start () {
		_eventCheck += OnAchievementUpEvent;
		_eventCheck += OnCollectingEvent;
		_eventCheck += OnDestroyBuildingEvent;
		_eventCheck += OnEnemyDeathEvent;
		_eventCheck += OnPlayerDeathEvent;
		_eventCheck += OnUpgradeVillageEvent;
		_eventCheck += OnWavespawnEvent;
		_eventCheck += OnEndGameEvent;
		_eventCheck += OnGiveMaterialEvent;
	}
	
	// Update is called once per frame
	void Update () {
		if (_eventCheck != null) {
			_eventCheck ();
		}
	}

	private void OnAchievementUpEvent ()
	{
		if(OnAchievementUp != null)
		{
			if (upgradedAchievment != Achievment.NONE) {
				OnAchievementUp (upgradedAchievment, upgradedAchievmentLevel);
				upgradedAchievment = Achievment.NONE;
			}
		}
	}

	private void OnCollectingEvent()
	{
		if(OnCollecting != null)
		{
			if (CollectedResource != Resource.NONE) {
				OnCollecting (CollectedResource, 1);
				CollectedResource = Resource.NONE;
			}
		}
	}

	private void OnDestroyBuildingEvent()
	{
		if(OnDestroyBuilding != null)
		{
			if(false)//exchange for condition
			OnDestroyBuilding ();
		}
	}

	private void OnEnemyDeathEvent()
	{
		if(OnEnemyDeath != null)
		{
			if(false)//exchange for condition
			OnEnemyDeath ();
		}
	}

	private void OnPlayerDeathEvent ()
	{
		if(OnPlayerDeath != null)
		{
			if(false)//exchange for condition
			OnPlayerDeath ();
		}
	}

	private void OnUpgradeVillageEvent()
	{
		if(OnUpgradeVillage != null)
		{
			if(UpgradeCost != 0)//exchange for condition
			OnUpgradeVillage ( Resource.COIN , -UpgradeCost);
			UpgradeCost = 0;
		}
	}

	private void OnWavespawnEvent ()
	{
		if(OnWavespawn != null)
		{
			if(false)//exchange for condition
			OnWavespawn ();
		}
	}

	private void OnEndGameEvent()
	{
		if(OnEndGame != null)
		{
			if(false)//exchange for condition
			OnEndGame ();
		}
	}

	//specialize
	private void OnGiveMaterialEvent()
	{
		if(OnGiveMaterial != null)
		{
			if (_givenResource != Resource.NONE)
			{
				OnGiveMaterial (_givenResource, _givenAmount, _takenResource, _takenAmount );
				_givenResource = Resource.NONE;
			}
		}
	}
}

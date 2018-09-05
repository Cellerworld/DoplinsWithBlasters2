using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public enum Resource {WOOD, COIN, POTION, MEGAPOTION, BERRY, MEAT, TREASURE};
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

	//hud and wavespawner are intrested in this
	public delegate void Wavespawn();
	public static event Wavespawn OnWavespawn;

	//upgrade NPC, the town and the player is intrested in this
	public delegate void UpgradeVillage();
	public static event UpgradeVillage OnUpgradeVillage;

	public delegate void DestroyBuilding();
	public static event DestroyBuilding OnDestroyBuilding;

	//Hud and trophy gallery is intrested in this
	public delegate void AchievmentUp(Achievment pAchievment, int pAchievmentLevel);
	public static event AchievmentUp OnAchievementUp;
	public static Achievment upgradedAchievment = Achievment.NONE;
	public static int upgradedAchievmentLevel;

	//player and interacted npc are intrested in this
	public delegate void GiveMaterial(Resource pResource, int pAmount);
	public static event GiveMaterial OnGiveMaterial;

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
			OnCollecting (Resource.WOOD, 1);
		}
	}

	private void OnDestroyBuildingEvent()
	{
		if(OnDestroyBuilding != null)
		{
			OnDestroyBuilding ();
		}
	}

	private void OnEnemyDeathEvent()
	{
		if(OnEnemyDeath != null)
		{
			OnEnemyDeath ();
		}
	}

	private void OnPlayerDeathEvent ()
	{
		if(OnPlayerDeath != null)
		{
			OnPlayerDeath ();
		}
	}

	private void OnUpgradeVillageEvent()
	{
		if(OnUpgradeVillage != null)
		{
			OnUpgradeVillage ();
		}
	}

	private void OnWavespawnEvent ()
	{
		if(OnWavespawn != null)
		{
			OnWavespawn ();
		}
	}

	private void OnEndGameEvent()
	{
		if(OnEndGame != null)
		{
			OnEndGame ();
		}
	}

	private void OnGiveMaterialEvent()
	{
		if(OnGiveMaterial != null)
		{
			OnGiveMaterial (Resource.MEAT, 1);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Granny : MonoBehaviour {

    public int goldNeeded;
    public GameObject textbox;
    private bool playerIsNearby;
    public Player player;
    public GameObject upgrade;
	[SerializeField]
	private Inventory _playerinventory;

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && playerIsNearby && _playerinventory.CoinAmount >= goldNeeded)
        {
			GameEventManager.UpgradeCost = goldNeeded;
            //player.RemoveGold(goldNeeded);
            UpgradeTown();
        }
    }

    private void UpgradeTown()
    {
        upgrade.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Text text = textbox.GetComponentInChildren<Text>();
            text.text = "Come back with " + goldNeeded + " gold.";
            Vector3 pos = transform.position;
            pos.y = 1;
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
}

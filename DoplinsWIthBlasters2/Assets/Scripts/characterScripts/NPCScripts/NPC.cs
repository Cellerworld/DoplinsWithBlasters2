using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public int stuffNeeded;
    public int goldReward;
    public float range;
    public GameObject textbox;
    private bool playerIsNearby = false;
    public Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsNearby && player.GetStuffCount() >= stuffNeeded)
        {
            player.MakeExchange(stuffNeeded, goldReward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 pos = transform.position;
            pos.y = 1;
            textbox.transform.position = pos;
            Text text = textbox.GetComponentInChildren<Text>();
            text.text = "Give me " + stuffNeeded + " stuff.";
            textbox.SetActive(true);
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsNearby = false;
            textbox.SetActive(false);
        }
    }
}

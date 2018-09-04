using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private int stuffCounter;
    private int goldCounter;
    public float speed = 20f;
    private Rigidbody rb;
    public Text text;
    public Text goldText;
    private Animator anim;
    private Sword sword;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sword = GetComponentInChildren<Sword>();
    }

    void Update () {
        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            vel.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (vel.x != 0 || vel.z != 0)
        {
            vel.Normalize();
            rb.velocity = vel * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(vel);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Attack()
    {
        sword.isAttacking = true;
        anim.Play("Attack");
    }

    private void EndAttack()
    {
        sword.isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            other.enabled = false;
            Destroy(other.gameObject);
            stuffCounter++;
            text.text = "Stuff: " + stuffCounter;
            return;
        }
    }

    public void MakeExchange(int stuffAmount, int goldAmount)
    {
        stuffCounter -= stuffAmount;
        goldCounter += goldAmount;
        text.text = "Stuff: " + stuffCounter;
        goldText.text = "Gold: " + goldCounter;
    }

    public int GetStuffCount()
    {
        return stuffCounter;
    }

    public int GetGoldCount()
    {
        return goldCounter;
    }

    public void RemoveGold(int amount)
    {
        goldCounter -= amount;
        goldText.text = "Gold: " + goldCounter;
    }
}

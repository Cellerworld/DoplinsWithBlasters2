using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	//transfer to Inventory/ complete for all resources
    private int stuffCounter;
    private int woodCounter;
    private int goldCounter;


	//move to stats maybe
	[SerializeField]
	private  float _speed = 20f;
	public float Speed
	{
		get
		{
			return _speed;
		}
		set
		{
			_speed = value;
		}
	}
    private Rigidbody rb;
	//move away to hud
//    public Text text;
//    public Text woodText;
//    public Text goldText;
   // private Sword sword;

	private Animator _animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //sword = GetComponentInChildren<Sword>();
		_animator = this.GetComponentInChildren<Animator> ();
    }

    void Update () {
        Vector3 vel = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
			_animator.SetTrigger ("move");
            vel.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
			_animator.SetTrigger ("move");
            vel.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
			_animator.SetTrigger ("move");
            vel.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
			_animator.SetTrigger ("move");
            vel.x = 1;
        }
        
        if (vel.x != 0 || vel.z != 0)
        {
            vel.Normalize();
            rb.velocity = vel * _speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(vel);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


	//move to attack script
  

	//move to collect and hud script
//    private void OnTriggerEnter(Collider other)
//    {
//        if(other.CompareTag("Collectable"))
//        {
//            other.enabled = false;
//            Destroy(other.gameObject);
//            stuffCounter++;
//            //text.text = "Stuff: " + stuffCounter;
//            return;
//        }
//        if (other.CompareTag("Wood") && other.GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
//        {
//            other.enabled = false;
//            Destroy(other.gameObject);
//            woodCounter++;
//           // woodText.text = "Wood: " + woodCounter;
//            return;
//        }
//    }

	//interaction script
//    public void MakeExchange(int stuffAmount, int goldAmount)
//    {
//        stuffCounter -= stuffAmount;
//        goldCounter += goldAmount;
////        text.text = "Stuff: " + stuffCounter;
////        goldText.text = "Gold: " + goldCounter;
//    }

	//inventory
//    public int GetStuffCount()
//    {
//        return stuffCounter;
//    }
//	//move to inventroy
//    public int GetGoldCount()
//    {
//        return goldCounter;
//    }

	//move to inventory
//    public void RemoveGold(int amount)
//    {
//        goldCounter -= amount;
////        goldText.text = "Gold: " + goldCounter;
//    }
}

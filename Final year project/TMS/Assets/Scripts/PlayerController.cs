using UnityEngine;
using System.Collections;



public class PlayerController : characterController 
{
	//vars
	public Vector3 moveTarget;
	public GameObject target;
	public item weapon;

	public PlayerController()
	{
		maxHealth = 10;
		currentHealth = maxHealth;
		maxMana = 5;
		currentMana = maxMana;
		level = 1;

		damage = 1;
		attackSpeed = 0.1f;

		state = "idle";

		speed = 3.0f;
	}

	// Use this for initialization
	void Start () 
	{
		me = GameObject.FindGameObjectWithTag("Player");
		Vector3 moveTarget = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	public void attack(GameObject target)
	{
		if (state == "attacking")
			if (target.GetComponent<characterController>().getState() != "dead")
		{
			//Debug.Log("time = " + Time.time.ToString());
			if (Time.time - lastAttack > attackSpeed)
			{
				lastAttack = Time.time;
				//Debug.Log("ATTACK");
				target.GetComponent<characterController>().currentHealth -= damage;
				//Debug.Log(target.GetComponent<characterController>().currentHealth.ToString());
				if (target.GetComponent<characterController>().currentHealth <= 0)
				{
					setState("idle");
					target.GetComponent<characterController>().setState("dead");
					Destroy(target.gameObject);
					target = gameObject;

				}
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{


		//Debug.Log("My health is " + currentHealth.ToString());

		//Debug.Log(state);
		if (moveTarget.x!= 0)
		{
			MoveToTarget(moveTarget,speed);
			state = setState(target);
		}

		if (transform.position == moveTarget & state != "attacking")
			state = "idle";

		if (target!=null)
		{
			attack(target);
		}

		//check if above floor
		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.down, out hit)) 
		{
			if (hit.collider.name == "null")
			{
				Debug.DrawRay(transform.position,Vector3.down);
				state = "idle";
				moveTarget.x=0;	
			}
		}
		base.Update();
	}
}
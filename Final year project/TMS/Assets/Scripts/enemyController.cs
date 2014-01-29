using UnityEngine;
using System.Collections;

public class enemyController : characterController {

	public Vector3 moveTarget;
	public GameObject target;
	public string currentState; //used for debug
 	//GameObject player;

	public enemyController()
	{
	}

	public void attack(GameObject target)
	{
		if (state == "attacking")
			if (target.GetComponent<characterController>().getState() != "dead")
		{
			//Debug.Log("time = " + Time.time.ToString());
			if (Time.time - lastAttack > attackSpeed && Vector3.Distance(this.transform.position,target.transform.position) < 3)
			{
				lastAttack = Time.time;
				//Debug.Log("ATTACK");
				target.GetComponent<characterController>().currentHealth -= damage;
				Debug.Log(target.GetComponent<characterController>().currentHealth.ToString());
				if (target.GetComponent<characterController>().currentHealth <= 0)
				{
					setState("idle");
					target.GetComponent<characterController>().setState("dead");

					//game over stuff

					target = null;
					
				}
			}
		}
	}


	// Use this for initialization
	void Start () 
	{
		/*
		maxHealth = 10;
		currentHealth=maxHealth;
		maxMana = 5;
		currentMana=maxMana;
		level = 1;
		
		damage = 1;
		attackSpeed = 2;
		
		state = "idle";
		
		speed = 3.0f;
		*/

		player = GameObject.Find("Player");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log("Base update");


		if (moveTarget.x!= 0)
		{
			MoveToTarget(moveTarget,speed);
		}
		if (target != null)
			state = setState(target);

		if (Vector3.Distance(player.transform.position,this.transform.position) < 10)
		{
			target = player;
			moveTarget = player.transform.position;
		}
		else
		{
			target = null;
			state = "idle";
			moveTarget.x = 0;
		}

	




		if (target!=null)
			attack(target);

		if (transform.position == moveTarget & state != "attacking")
			state = "idle";

		currentState = state;

		base.Update();

		currentState = state;

	}
}

using UnityEngine;
using System.Collections;

public class characterController : SpriteController 
{

	//Character attributes

	public static GameObject me;

	public int maxHealth;
	public int currentHealth;

	public int maxMana;
	public int currentMana;
	public int level;

	public int damage;
	public float attackSpeed;
	public float lastAttack;
	public string state;

	public characterController()
	{
	}

	public characterController(int h,int m, int l, int d, int aa, GameObject myObj)
	{
		maxHealth = h;
		maxMana = m;
		level = l;
		damage = d;
		attackSpeed = aa;
		lastAttack = Time.time;

		me = myObj;
		state = "idle";
	}

	public string getState()
	{
		return state;
	}

	public void checkIfDead()
	{
		if (currentHealth <= 0)
		{
			//Debug.Log(me.name.ToString());
			setState("dead");
			Destroy(me);
		}
	}



	public void setState (string str)
	{
		state = str;
	}

	public string setState(GameObject target)
	{
		if(target.tag !="")
		{
			switch (target.tag)
			{
			case null:
				return "idle";
				break;
			case "floor":
				return "moving";
				break;
			case "enemy":
				if (Vector3.Distance(this.transform.position,target.transform.position) < 2)
					return "attacking";
				else
					return "moving";
				break;
			case "Player":
				if (Vector3.Distance(this.transform.position,target.transform.position) < 2)
				{
					return "attacking";
					Debug.Log (Vector3.Distance(this.transform.position,target.transform.position).ToString());
				}
					else
				{
					Debug.Log(Vector3.Distance(this.transform.position,target.transform.position).ToString());
					return "moving";
				}
				break;
			case "item":
				return "moving";
				break;
			default:
				return "idle";
				break;
			}
		}else
			return "idle";
	}
	// Use this for initialization
	void Start () 
	{
	
	}


	// Update is called once per frame
	public void Update () 
	{		
		base.Update();
		//stops the player moving if they are attacking
		if (state == "attacking" & this.gameObject.tag == "Player")
		{
			//Debug.Log("Stopping player");
			pc.moveTarget =(transform.position);
			pc.moveTarget.x= 0;
		}

		//stop the enemies moving when they are attacking
		if(state == "attacking" & this.gameObject.tag =="enemy")
		{
			//Debug.Log("Stopping enemy");
			enemyController ec = this.GetComponent<enemyController>();
			ec.moveTarget = (transform.position);
			ec.moveTarget.x=0;
		}
		

	//	checkIfDead();

	}
}

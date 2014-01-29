using UnityEngine;
using System.Collections;



public class SpriteController : inputController {

	static Vector3 moveTarget;
	public float speed;
	// Use this for initialization

	public SpriteController()
	{
		speed = 0.0f;
	}

	public void Start () 
	{
		Vector3 moveTarget = new Vector3 (0.0f, 0.0f, 0.0f);

	}
	
	// Update is called once per frame
	public void Update () 
	{
		base.Update();
		//if (moveTarget.x!= 0)
		//	this.MoveToTarget(moveTarget,speed);
	}
	
	public virtual void MoveToTarget(Vector3 target, float speed)
	{
		moveTarget = target;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

}


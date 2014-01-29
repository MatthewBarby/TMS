using UnityEngine;
using System.Collections;

public class item : SpriteController {

	public int id;
	public string name;
	public Material icon;
	public Sprite image;
	public string type;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();
	
	}

	public item()
	{

	}

	public virtual void function()
	{
	}
}

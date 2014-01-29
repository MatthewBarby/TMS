using UnityEngine;
using System.Collections;

public class weapon : item {

	//public int id;
	//public string name;
	//public Material icon;
	//public Sprite image;
	//public string type;

	public Sprite[] icons;
	public int damage;
	public float attackSpeed;
	public bool pickedUp;
	public inventoryManager im;

	public GameObject equippedWeapon;
	// Use this for initialization
	void Start () 
	{
		im =GameObject.Find("gameManager").GetComponent<inventoryManager>();
		pickedUp = false;
		GameObject p = GameObject.Find("Player");
		PlayerController cc = p.GetComponent<PlayerController>();
		int l = cc.level;
		damage = (int)Mathf.Floor(Random.Range(1.0f*l,5.0f*l));
		attackSpeed = Random.Range(0.05f,0.3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Hit");
		if(collider.gameObject.tag == "Player")
		{
			Debug.Log("Hit Player");
			im.pickUp(this.transform);
		}
	}
}

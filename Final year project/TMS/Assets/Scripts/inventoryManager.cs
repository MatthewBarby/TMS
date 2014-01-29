using UnityEngine;
using System.Collections;

public class inventoryManager : MonoBehaviour {

	public Transform player;


	public bool closed = true;
	public Vector3 openPos,closePos;
	public const int inventoryLimit = 10;
	public Transform[] inventorySlots;
	public Transform[] items;
	public Transform weaponPrefab;
	public Transform potionPrefab;
	public Transform equipedWeapon;
	public Transform nextFreeInventorySlot;
	// Use this for initialization
	void Start () 
	{
	
		items = new Transform[inventoryLimit];
		for(int i=0;i<inventoryLimit;i++)
		{
			items[i] = null;
		}
		Transform clone;
		Debug.Log("Slot x = " + inventorySlots[7].transform.position.x.ToString());
		clone = (Transform)Instantiate(weaponPrefab,inventorySlots[0].transform.position,Quaternion.identity);
		items[0] = clone;
		equipedWeapon = clone;
		clone.name = "Sword";
		clone.parent=inventorySlots[0];

		nextFreeInventorySlot = findNextSlot();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	public void pickUp(Transform item)
	{
		int i=0;
		while(items[i] != null || i > inventoryLimit)
		{
			i++;
		}

		if (i<inventoryLimit)
		{
			items[i] = item;
			item.transform.position= inventorySlots[i].transform.position;
			item.transform.parent = inventorySlots[i];
		}



	}
	public Transform findNextSlot()
	{
		int i=0;
		while(items[i] != null || i > inventoryLimit)
		{
			i++;
		}
		if (i<inventoryLimit)
		{	Debug.Log(inventorySlots[i].name.ToString());
			return inventorySlots[i];
		}
		else
			return null;
	}

	public void move()
	{
		Debug.Log("Calling move");
		GameObject inventory = GameObject.Find("InventoryBackground");
		if(closed)
		{
			closePos = this.transform.localPosition;
			openPos = new Vector3(closePos.x-5,closePos.y,closePos.z);
			inventory.transform.localPosition = openPos;
			closed = false;
		}
		else
		{
			openPos = this.transform.localPosition;
			closePos = new Vector3(closePos.x+20,closePos.y,closePos.z);
			inventory.transform.localPosition = closePos;
			closed = true;
		}
	}
}

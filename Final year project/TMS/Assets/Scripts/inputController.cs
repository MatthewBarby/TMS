using UnityEngine;
using System.Collections;

public class inputController : MonoBehaviour {
	public GameObject player;
	public PlayerController pc;

	public inputController()
	{
	}
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		pc = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	public void Update () 
	{

		// code for handling inputs
		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(this.gameObject.name == "Player")
			{
				if (Physics.Raycast(ray, out hit))
				{					
					if (hit.collider.tag == "floor" || hit.collider.tag == "enemy" || hit.collider.tag == "item")
					{
						GameObject player = GameObject.FindGameObjectWithTag("Player");
						pc.moveTarget = new Vector3(hit.point.x,1.0f,hit.point.z);
						pc.target = (hit.collider.gameObject);
					}

					if (hit.collider.tag == "button")
					{
						Debug.Log("Hit");
						GameObject.Find("gameManager").GetComponent<inventoryManager>().move();
						//move inventory
					}
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class newLevel : MonoBehaviour {

	private int xDiff=10;
	private int yDiff=10;
	private int zDiff = 50;
	public GameObject player;
	public GameObject startRoom;
	public Transform room;
	public Transform hall;



	// Use this for initialization
	void Start () 
	{
		makeNewLevel(100,100);
		player.transform.position = new Vector3(startRoom.transform.position.x,1,startRoom.transform.position.z);
	}
	
	// Update is called once per frame


	void makeNewLevel(int levelSize, int numRooms)
	{
		int[,] map = new int[levelSize,levelSize];

		//zero out array
		for(int i=0;i<levelSize;i++)
		{
			for (int j=0;j<levelSize;j++)
			{
				map[i,j] = 0;

			}
		}

		//make rooms
		float startX = Mathf.Round(levelSize/2);
		float startY = Mathf.Round(levelSize/2);
		int currentX = (int)startX;
		int currentY = (int)startY;
		//map[currentX,currentY]=1;
		while (numRooms > 0)
		{

			int r = Mathf.FloorToInt(Random.Range (0,5));

			//next room location
			switch (r)
			{
			case 0: //move up
				if (currentX == levelSize-1)
					break;
				currentX++;
				break;
			case 1: //move down
				if (currentX==0)
					break;
				currentX--;
				break;
			case 3: //right
				if (currentY == levelSize-1)
					break;
				currentY++;
				break;
			case 4: //left
				if (currentY==0)
					break;
				currentY--;
				break;
			default:
				break;
			}
			
			// if no room, add a room
			if (map[currentX,currentY] == 0)
			{

					//Debug.Log("Making room at " + currentX.ToString() + " " + currentY.ToString());
					map[currentX,currentY] = 1;
					numRooms--;
					//Debug.Log(numRooms.ToString() + " left");

					Transform clone;
					Vector3 pos = new Vector3(currentX*xDiff,0,currentY*yDiff); 
					clone = (Transform)Instantiate(room,pos,room.transform.rotation);

				if (!startRoom)
				{
					startRoom=clone.gameObject;
				}
			}
		}


		/*
		//add halls
		float hxDiff = 7.5f;
		float hyDiff = 7.5f;
		Debug.Log("Begin adding halls");
		int a = 0;
		int b = 0;
	
		for(a=0;a<levelSize;a++)
		{
			for (b=0;b<levelSize;b++)
			{

			//	Debug.Log(map[i,j].ToString());
				if (b!=levelSize-1) //if not at right
				{
					if(map[a,b] != 0 && map[a,b+1] != 0)
					{	//Debug.Log("Make a hall");
						Transform hallClone;
						Vector3 hallPos = new Vector3(a*xDiff, 0, b*yDiff+hyDiff);
						hallClone = (Transform)Instantiate(hall,hallPos,hall.transform.rotation);
						//add hall
					}
				}
				if(a!=levelSize-1) //if not at bottom
				{
					if(map[a,b]!=0&& map[a+1,b]!=0)
					{
						//Debug.Log("Make a hall");
						Transform hallClone;
						Vector3 hallPos = new Vector3(a*xDiff+hxDiff, 0, b*yDiff);
						hallClone = (Transform)Instantiate(hall,hallPos,hall.transform.rotation);
						//add hall
					}
				}
			}
		}
		*/
	}
}

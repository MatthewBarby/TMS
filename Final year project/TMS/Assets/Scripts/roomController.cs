using UnityEngine;
using System.Collections;

public class roomController : MonoBehaviour {

	public Transform goblin;
	public Transform weapon;

	// Use this for initialization
	void Start () 
	{
		Transform clone;
		clone = (Transform) Instantiate(goblin,transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

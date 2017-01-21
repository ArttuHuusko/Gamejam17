using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public int health = 5;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			Debug.Log ("We be sinking mateys!! Abandon ship!");
			health = 0;
		}
	}
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == ("enemy")) 
		{
			health--;
			Debug.Log ("We be hit sire");
		}
	}
}

using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public int enemyHp;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHp <= 0) 
		{
			Debug.Log ("oh shit what doned");
			Destroy (gameObject);
		}
	}
	public void takeDamage()
	{
		enemyHp--;
	}
}

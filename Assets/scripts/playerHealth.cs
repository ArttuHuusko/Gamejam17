using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public int health = 5;
	public Text YouLose;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			YouLose.text = "Yer ship be sunk matey!";
			health = 0;
			StartCoroutine (Restart());
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "enemyFire")
		{
			takeDamage ();
			Destroy (coll.gameObject);
		}
	}
	public void takeDamage ()
	{
		health--;
	}
	IEnumerator Restart()
	{
		yield return new WaitForSeconds (10);
		Application.LoadLevel (Application.loadedLevel);
	}
}

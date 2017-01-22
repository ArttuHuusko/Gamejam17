using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public int health = 5;
	public Text YouLose;
	public GameObject LoseBack;
	public ParticleSystem explosion;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			LoseBack.SetActive (true);
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
			Vector3 spawnPos = coll.transform.position;
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (explosion,spawnPos,spawnRotation);
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

using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public GameObject spawner;
	public Spawner wave;
	public int enemyHp;
	// Use this for initialization
	void Start () 
	{
		spawner = GameObject.Find ("spawner");
		wave = spawner.GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHp <= 0) 
		{
			Debug.Log ("oh shit what doned");
			wave.progressWave ();
			Destroy (gameObject);
		}
	}
	public void takeDamage()
	{
		enemyHp--;
	}
}

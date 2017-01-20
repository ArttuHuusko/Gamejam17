using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyArray;
	public Vector3 spawnValues;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (1);
		while (true) 
		{
			Vector3 spawnPos = new Vector3 (-spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (enemyArray[1], spawnPos, spawnRotation);
			yield return new WaitForSeconds (1);
		}
		yield return new WaitForSeconds (20);
	}
}

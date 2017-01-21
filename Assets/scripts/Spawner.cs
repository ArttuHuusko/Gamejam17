using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyArray;
	public Vector3 spawnValues;
	public int spawnCounter;
	public int waveCounter = 1;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public bool spawning = false;
	public int waveProgress;
	public int currentWave;
	public Transform[] spawnPoints;
	public int i;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWave ());
	}
	
	// Update is called once per frame
	void Update () {
		spawnValues = gameObject.transform.position;
	}
	public void progressWave()
	{
		waveProgress++;
	}
	IEnumerator SpawnWave ()
	{
		yield return new WaitForSeconds (startWait);
		spawning = true;
		while (spawning == true) 
		{
			i = Random.Range(0,3);
			Transform pos = spawnPoints[i];
			Quaternion spawnRotation = Quaternion.identity;
			if (waveCounter == 1) 
			{
				currentWave = 2;
				if (spawnCounter < 2)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
				
			}
			if (waveCounter == 2) 
			{
				currentWave = 4;
				if (spawnCounter < 4)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
			/*	if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [1], pos.position, pos.rotation);	*/
			}
			if (waveCounter == 3) 
			{
				currentWave = 6;
				if (spawnCounter < 6)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
			/*	if (spawnCounter > 3 && spawnCounter < 7)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
				if (spawnCounter == 7)
					Instantiate (enemyArray [2], pos.position, pos.rotation);	*/
			}
			if (waveCounter == 4) 
			{
				currentWave = 8;
				if (spawnCounter < 8)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
			/*	if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [2], pos.position, pos.rotation); */
			}
			if (waveCounter == 5) 
			{
				currentWave = 10;
				if (spawnCounter < 10)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
			/*	if (spawnCounter > 4 && spawnCounter < 8)
					Instantiate (enemyArray [2], pos.position, pos.rotation); */
			}
			spawnCounter ++ ;
			yield return new WaitForSeconds (spawnWait);

			if (waveProgress == currentWave) 
			{
				spawnCounter = 0;
				waveCounter++;
				waveProgress = 0;
			}
		}
		yield return new WaitForSeconds (waveWait);
		spawning = true;
	}
}

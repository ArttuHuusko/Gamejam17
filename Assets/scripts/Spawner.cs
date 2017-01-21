using UnityEngine;
using System.Collections;

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
			Vector3 spawnPos = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			if (waveCounter == 1) 
			{
				if (spawnCounter < 8)
					Instantiate (enemyArray [0], spawnPos, spawnRotation);
				
			}
			if (waveCounter == 2) 
			{
				if (spawnCounter < 6)
					Instantiate (enemyArray [0], spawnPos, spawnRotation);
				if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [1], spawnPos, spawnRotation);
			}
			if (waveCounter == 3) 
			{
				if (spawnCounter < 4)
					Instantiate (enemyArray [0], spawnPos, spawnRotation);
				if (spawnCounter > 3 && spawnCounter < 7)
					Instantiate (enemyArray [1], spawnPos, spawnRotation);
				if (spawnCounter == 7)
					Instantiate (enemyArray [2], spawnPos, spawnRotation);
			}
			if (waveCounter == 4) 
			{
				if (spawnCounter < 6)
					Instantiate (enemyArray [1], spawnPos, spawnRotation);
				if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [2], spawnPos, spawnRotation);
			}
			if (waveCounter == 5) 
			{
				if (spawnCounter < 5)
					Instantiate (enemyArray [1], spawnPos, spawnRotation);
				if (spawnCounter > 4 && spawnCounter < 8)
					Instantiate (enemyArray [2], spawnPos, spawnRotation);
			}
			spawnCounter ++ ;
			yield return new WaitForSeconds (spawnWait);

			if (waveProgress == 8) 
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

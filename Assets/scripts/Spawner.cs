using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
	public GameObject WinBack;
	public Text WinText;
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
				currentWave = 6;
				if (spawnCounter < 6)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
				
			}
			if (waveCounter == 2) 
			{
				currentWave = 10;
				if (spawnCounter < 10)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
			/*	if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [1], pos.position, pos.rotation);	*/
			}
			if (waveCounter == 3) 
			{
				currentWave = 13;
				if (spawnCounter < 13)
					Instantiate (enemyArray [0], pos.position, pos.rotation);
			/*	if (spawnCounter > 3 && spawnCounter < 7)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
				if (spawnCounter == 7)
					Instantiate (enemyArray [2], pos.position, pos.rotation);	*/
			}
			if (waveCounter == 4) 
			{
				currentWave = 16;
				if (spawnCounter < 16)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
			/*	if (spawnCounter > 5 && spawnCounter < 8)
					Instantiate (enemyArray [2], pos.position, pos.rotation); */
			}
			if (waveCounter == 5) 
			{
				currentWave = 23;
				if (spawnCounter < 23)
					Instantiate (enemyArray [1], pos.position, pos.rotation);
			/*	if (spawnCounter > 4 && spawnCounter < 8)
					Instantiate (enemyArray [2], pos.position, pos.rotation); */
			}
			if (waveCounter == 6) 
			{
				StartCoroutine (Restart ());
				WinBack.SetActive(true);
				WinText.text = "The royal navy got a meetin' with Ol' Davy Jones!";
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
	IEnumerator Restart()
	{
		yield return new WaitForSeconds (10);
		Application.LoadLevel (Application.loadedLevel);
	}
}

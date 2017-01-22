using UnityEngine;
using System.Collections;

public class repairScript : MonoBehaviour {

    public playerHealth healthScript;
	int startHealth;

	// Use this for initialization
	void Start () 
    {
        healthScript = GetComponent<playerHealth>();
		startHealth = healthScript.health;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void RepairFunc()
    {
		if (healthScript.health < startHealth)
        {
            healthScript.health++;
        }
        else
        {
            Debug.Log("Full health already");
        }
    }
}

using UnityEngine;
using System.Collections;

public class repairScript : MonoBehaviour {

    public playerHealth healthScript;

	// Use this for initialization
	void Start () 
    {
        healthScript = GetComponent<playerHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void RepairFunc()
    {
        if (healthScript.health < 10)
        {
            healthScript.health++;
        }
        else
        {
            Debug.Log("Full health already");
        }
    }
}

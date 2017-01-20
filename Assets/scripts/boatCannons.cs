using UnityEngine;
using System.Collections;

public class boatCannons : MonoBehaviour {

    public KeyCode CannonShoot = KeyCode.T;
    public GameObject cannonBall;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(CannonShoot))
        {
            Instantiate(cannonBall, this.transform.position, Quaternion.identity);
        }
	}
}

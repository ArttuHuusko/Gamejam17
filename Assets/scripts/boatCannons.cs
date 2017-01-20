using UnityEngine;
using System.Collections;

public class boatCannons : MonoBehaviour {


    public GameObject boat;
    public KeyCode CannonShoot = KeyCode.T;
    public GameObject cannonBall;

	// Use this for initialization
	void Start () 
    {
        boat = GameObject.Find("boat");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(CannonShoot))
        {
            Instantiate(cannonBall, this.transform.position, boat.transform.rotation);
        }
	}
}

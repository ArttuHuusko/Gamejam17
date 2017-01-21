using UnityEngine;
using System.Collections;

public class AICannons : MonoBehaviour {

    public GameObject cannonBall;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void FireCannons()
    {
        Instantiate(cannonBall, this.transform.position, transform.parent.rotation);
    }
}

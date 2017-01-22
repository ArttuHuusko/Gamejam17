using UnityEngine;
using System.Collections;

public class boatCannons : MonoBehaviour {


    public GameObject boat;
    public KeyCode CannonShoot = KeyCode.T;
    public GameObject cannonBall;
	public bool cannonLoaded = true; 
	//public KeyCode Reload = KeyCode.R;
	public ParticleSystem cannonfire;

    public GameObject cannonReloadUI;
    public sideCannonDrag cannonScript;

	// Use this for initialization
	void Start () 
    {
        boat = GameObject.Find("playerBoat");
        cannonLoaded = false;
        cannonScript = cannonReloadUI.GetComponent<sideCannonDrag>();
	}

    public void ReloadComplete()
    {
        cannonLoaded = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
		if (cannonLoaded == true) 
		{
			if (Input.GetKeyDown (CannonShoot)) 
			{
				Instantiate (cannonBall, this.transform.position, boat.transform.rotation);
				cannonLoaded = false;
				cannonfire.Play ();
                cannonScript.CannonShot();
			}
		}	
	}
}

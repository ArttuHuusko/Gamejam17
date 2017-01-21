using UnityEngine;
using System.Collections;

public class AIDodge : MonoBehaviour {

    public GameObject parentBoat;

    Vector3 currentRotation;

    public AIMovement boatScript;

    bool evasionActive = false;
    float evasionTimer = 3f;

	// Use this for initialization
	void Start () 
    {
        parentBoat = transform.parent.gameObject;
        boatScript = parentBoat.GetComponent<AIMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //forces boat local y velocity to 0 i.e disables drifting
        Vector3 localVel = transform.InverseTransformDirection(boatScript.body.velocity);
        localVel.y = boatScript.maxSpeed;
        boatScript.body.velocity = transform.TransformDirection(localVel);
        //forces boat local y velocity to 0 i.e disables drifting

        if (evasionActive == true)
        {
            evasionTimer -= Time.fixedDeltaTime;

           // //moves boat forward at maxSpeed and doesnt let it go over that value
           // if (boatScript.body.velocity.magnitude > boatScript.maxSpeed)
           // {
           //     boatScript.body.velocity = boatScript.body.velocity.normalized * boatScript.maxSpeed;
           // }
           // boatScript.body.AddRelativeForce(Vector2.up * boatScript.Speed);
           // //moves boat forward at maxSpeed and doesnt let it go over that value
           // if (boatScript.body.angularVelocity > boatScript.maxTurnRate)
           // {
           //     boatScript.body.angularVelocity = boatScript.maxTurnRate;
           // }
        }
        if (evasionTimer <= 0)
        {
            evasionActive = false;
            boatScript.enabled = true;
            evasionTimer = 3f;
        }

	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            boatScript.enabled = false;

            currentRotation = transform.eulerAngles;
            currentRotation.z = Mathf.Lerp(currentRotation.z, Random.Range(-90, 90), 0.2f * Time.deltaTime);
            transform.eulerAngles = currentRotation;
            evasionActive = true;
        }
    }
}

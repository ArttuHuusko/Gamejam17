using UnityEngine;
using System.Collections;

public class AIDodge : MonoBehaviour {

    public GameObject parentBoat;

    Vector3 currentRotation;

    public GameObject objectToDodge;

    public AIMovement boatScript;

    bool evasionActive = false;
    float evasionTimer = 3f;
    public float dirNum;

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
        }   

        if (evasionTimer <= 0)
        {
            evasionActive = false;
            boatScript.enabled = true;
            evasionTimer = 3f;
        }



	}
    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);
        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "dodgeCollider")
        {

            objectToDodge = other.gameObject;

            boatScript.enabled = false;

            currentRotation = transform.eulerAngles;
            currentRotation.z = Mathf.Lerp(currentRotation.z, Random.Range(-90, 90), 0.2f * Time.deltaTime);
            transform.eulerAngles = currentRotation;
            evasionActive = true;
        }
    }
}

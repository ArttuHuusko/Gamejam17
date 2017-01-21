using UnityEngine;
using System.Collections;

public class AIDodge : MonoBehaviour {

    public GameObject parentBoat;

    Vector3 currentRotation;
    Vector3 newHeading;

    public GameObject objectToDodge;

    public AIMovement boatScript;

    bool evasionActive = false;
    bool colliding = false;
    float evasionTimer = 1.5f;
    public float dirNum;

	// Use this for initialization
	void Start () 
    {
        objectToDodge = null;
        parentBoat = transform.parent.gameObject;
        boatScript = parentBoat.GetComponent<AIMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        if (boatScript.enabled == false)
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
            if (colliding == true)
            {
                Vector3 diffAway = objectToDodge.transform.position - transform.position;
                diffAway.Normalize();
                float rot_zAway = Mathf.Atan2(diffAway.y, diffAway.x) * Mathf.Rad2Deg;
                rot_zAway = rot_zAway + 180;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_zAway);

                newHeading = objectToDodge.transform.eulerAngles;
                newHeading.z = Mathf.Lerp(objectToDodge.transform.rotation.z, rot_zAway, 0.5f * Time.deltaTime);
                objectToDodge.transform.eulerAngles = newHeading;
            }
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
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "dodgeCollider")
        {
            colliding = true;
            objectToDodge = other.transform.parent.gameObject;

            boatScript.enabled = false;
            evasionActive = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        objectToDodge = null;
        colliding = false;
        boatScript.enabled = true;
    }
}
